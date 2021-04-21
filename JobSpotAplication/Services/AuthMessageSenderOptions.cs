using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSpotAplication.Services
{
    public class AuthMessageSenderOptions
    {
        private string sendGridUser = "JobSpot";
        private string sendGridKey = "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";

        public string GetSendGridUser()
        {
            return sendGridUser;
        }

        public string GetSendGridKey()
        {
            return sendGridKey;
        }

    }
}
