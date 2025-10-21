namespace PairOfEmployees;

public partial class Form1 : Form
{
    private readonly string[] allowedDateFormats =
    {
        "yyyy-MM-dd",
        "dd-MM-yyyy",
        "MM-dd-yyyy"
    };

    public Form1()
    {
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        InitializeComponent();
    }

    private void browseBtn_Click(object sender, EventArgs e)
    {
        lblInfo.Text = string.Empty;
        dataGridView.Rows.Clear();

        var fileDialog = new OpenFileDialog
        {
            AddExtension = true,
            Filter = "CSV files (*.csv)|*.csv",
            Title = "Select CSV file"
        };

        var fileDialogResult = fileDialog.ShowDialog();

        if (fileDialogResult != DialogResult.OK) return;

        filePathTxt.Text = fileDialog.FileName;

        var employeesDict = ParseCsvFile(fileDialog.OpenFile());

        if (employeesDict is null) return;

        var longestWorkingPair = FindLongestWorkingPairOfEmployees(employeesDict);

        lblInfo.Text = $"{longestWorkingPair.FirstEmployeeId} and {longestWorkingPair.SecondEmployeeId} have worked together the longest - {longestWorkingPair.TotalWorkingDays} days.";

        foreach (var kvp in longestWorkingPair.WorkingDaysPerProject.OrderBy(s => s.Value))
            dataGridView.Rows.Add(longestWorkingPair.FirstEmployeeId, longestWorkingPair.SecondEmployeeId, kvp.Key, kvp.Value);
    }

    private Dictionary<int, Dictionary<int, List<WorkingPeriod>>>? ParseCsvFile(Stream file)
    {
        try
        {
            var employeesDict = new Dictionary<int, Dictionary<int, List<WorkingPeriod>>>();

            using var reader = new StreamReader(file);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (string.IsNullOrEmpty(line)) continue;

                var columns = line.Replace(" ", "").Split(',');
                var employeeId = int.Parse(columns[0]);
                var projectId = int.Parse(columns[1]);

                if (!employeesDict.TryGetValue(employeeId, out var projectsDict))
                {
                    projectsDict = [];
                    employeesDict[employeeId] = projectsDict;
                }

                if (!projectsDict.TryGetValue(projectId, out var projectPeriods))
                {
                    projectPeriods = [];
                    projectsDict[projectId] = projectPeriods;
                }

                var (dateFrom, format) = ParseDate(columns[2]);

                var dateTo = DateOnly.FromDateTime(DateTime.Today);

                if (columns[3] != "NULL")
                {
                    var (parsedDateTo, _) = ParseDate(columns[3]);
                    dateTo = parsedDateTo;
                }

                projectPeriods.Add(new WorkingPeriod(dateFrom, dateTo));
            }

            return employeesDict;
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message);
            filePathTxt.Text = string.Empty;

            return null;
        }
    }

    private (DateOnly ParsedDate, string ParsedFormat) ParseDate(string date)
    {
        foreach (var format in allowedDateFormats)
        {
            if (DateOnly.TryParseExact(date, format, out var parsedDate))
            {
                return (parsedDate, format);
            }
        }

        throw new InvalidOperationException("Invalid date format provided");
    }

    private LongestWorkingPairDto FindLongestWorkingPairOfEmployees(Dictionary<int, Dictionary<int, List<WorkingPeriod>>> employeesDict)
    {
        var longestWorkingPair = new LongestWorkingPairDto();

        var employeesIds = employeesDict.Keys.ToList();

        for (int i = 0; i < employeesIds.Count - 1; i++)
        {
            var firstEmployeeId = employeesIds[i];
            var firstEmployee = employeesDict[firstEmployeeId];

            for (int j = i + 1; j < employeesIds.Count; j++)
            {
                var totalWorkingDays = 0;
                var workingDaysPerProject = new Dictionary<int, int>();

                var secondEmployeeId = employeesIds[j];
                var secondEmployee = employeesDict[secondEmployeeId];

                foreach (var firstEmployeeProjectId in firstEmployee.Keys)
                {
                    if (!secondEmployee.ContainsKey(firstEmployeeProjectId)) continue;

                    foreach (var firstEmployeeWorkingPeriod in firstEmployee[firstEmployeeProjectId])
                    {
                        foreach (var secondEmployeeWorkingPeriod in secondEmployee[firstEmployeeProjectId])
                        {
                            var overlapingDays = CalculateOverlapingDays(firstEmployeeWorkingPeriod, secondEmployeeWorkingPeriod);

                            totalWorkingDays += overlapingDays;

                            if (!workingDaysPerProject.ContainsKey(firstEmployeeProjectId))
                                workingDaysPerProject[firstEmployeeProjectId] = 0;

                            workingDaysPerProject[firstEmployeeProjectId] += overlapingDays;
                        }
                    }
                }

                if (totalWorkingDays > longestWorkingPair.TotalWorkingDays)
                {
                    longestWorkingPair = new LongestWorkingPairDto
                    {
                        FirstEmployeeId = firstEmployeeId,
                        SecondEmployeeId = secondEmployeeId,
                        TotalWorkingDays = totalWorkingDays,
                        WorkingDaysPerProject = workingDaysPerProject
                    };
                }
            }
        }

        return longestWorkingPair;
    }

    private int CalculateOverlapingDays(WorkingPeriod firstEmployeeWorkingPeriod,
                                        WorkingPeriod secondEmployeeWorkingPeriod)
    {
        var startOfOverlap = firstEmployeeWorkingPeriod.DateFrom;

        if (startOfOverlap < secondEmployeeWorkingPeriod.DateFrom)
            startOfOverlap = secondEmployeeWorkingPeriod.DateFrom;

        var endOfOverlap = firstEmployeeWorkingPeriod.DateTo;

        if (endOfOverlap > secondEmployeeWorkingPeriod.DateTo)
            endOfOverlap = secondEmployeeWorkingPeriod.DateTo;

        if (endOfOverlap < startOfOverlap) return 0;

        var overlapingDays = endOfOverlap.DayNumber - startOfOverlap.DayNumber + 1;

        return overlapingDays <= 0 ? 0 : overlapingDays;
    }
}
