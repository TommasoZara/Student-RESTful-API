using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Enums
    {
        public enum Status { Ready, InProgress, Finish }

        public enum ErrorCode
        {
            RequiredOtherFields, 
            IDInUse,  
            RecordNotFound, 
            CouldNotCreate, 
            CouldNotUpdate, 
            CouldNotDelete,
            Unauthorized,
            InvalidCredential
        }


    }
}
