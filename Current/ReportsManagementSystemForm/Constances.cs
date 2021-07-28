namespace ReportsManagementSystemForm
{
    public partial class Pass { }
    
    public class Constances
    {
        public const int STATUS_ACTIVE = 1;
        public const int STATUS_NOT_ACTIVE = 2;
        public const int STATUS_RECEIVING_FILES = 8;
        public const int STATUS_RECEIVING_FILES_ERROR = 9;
        public const int STATUS_RECORD_HANDLING = 10;
        public const int STATUS_RECORD_HANDLING_ERROR = 11;

        public const int PERMISSION_USERS_MANAGEMENT = 1;
        public const int PERMISSION_REPORTS_MANAGEMENT = 2;
        public const int PERMISSION_DIRECTORY_MANAGEMENT = 3;
        public const int PERMISSION_REPORTS_INSTANCES_CREATING = 4;
        public const int PERMISSION_REPORTS_INSTANCES_UPDATING = 5;
        public const int PERMISSION_REPORTS_INSTANCES_READING = 6;

        public const int ERROR_PARAMS_ERROR = 1;
        public const int ERROR_ACCESS_DENIED_ERROR = 2;
        public const int ERROR_SOURSE_NOT_FOUND_ERROR = 3;
        public const int ERROR_RECORD_ALREADY_EXISTS_ERROR = 5;

        public const int DIRECTORY_DEPARTMENT_UNKNOWN_ID = 1;

        public const string INSTANCE_HOME_DIR_PATH = "\\\\bookcentre.ru\\root\\IA_DIVIZION\\Public\\Reports";
        public const string INSTANCE_REMOTE_EXEC_FILE = "!myFiles\\reportsManagementSystem_handler_exec.exe";

        public const string APP_HELP_FILE = "!myFiles\\instruction.pdf";
    }
}