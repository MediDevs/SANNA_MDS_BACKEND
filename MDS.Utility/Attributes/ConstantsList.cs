using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Utility.Attributes
{
    public  class ConstantsList
    {
        public const int VALUES_DEFAULT_INT = 0;

        #region STATUS CODE 
        public const int STATUS_CODE_200 = 200;
        public const int STATUS_CODE_201 = 201;
        public const int STATUS_CODE_204 = 204;
        public const int STATUS_CODE_401 = 401;
        public const int STATUS_CODE_404 = 404;
        public const int STATUS_CODE_409 = 409;
        public const int STATUS_CODE_422 = 422;
        public const int STATUS_CODE_500 = 500;
        public const int STATUS_CODE_598 = 598;
        public const int STATUS_CODE_599 = 599;
        #endregion

        #region STATUS
        public const string STATUS_SUCCESS = "SUCCESS";
        public const string STATUS_ERROR = "ERROR";
        #endregion

        #region AUTH
        public const int AUTH_MAX_ATTEMPS = 3;
        public const bool AUTH_TWO_FACTOR_ON = true;
        public const bool AUTH_TWO_FACTOR_OFF = false;
        public const bool AUTH_STATUS_ON = true;
        public const bool AUTH_STATUS_OFF = false;
        public const string AUTH_ERROR_NOT_EXISTS = "NOT EXISTS";
        public const string AUTH_ERROR_WRONG_PASSWORD = "WRONG PASSWORD";
        public const string AUTH_ERROR_TWO_FACTOR = "TWO FACTOR AUTHENTICATOR";
        public const string AUTH_ERROR_MAX_ATTEMPS = "MAX ATTEMPS";
        public const string AUTH_ERROR_STATUS = "ACCOUNT DISABLE";
        public const string AUTH_ERROR_EMAIL_CONFIRMATION = "EMAIL CONFIRMATION";
        #endregion
    }
}
