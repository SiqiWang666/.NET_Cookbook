using System;

namespace PracticeNotebook
{
    public class ExceptionExample
    {
        public void HandleException()
        {
            /*
             * todo [review-class note 6/26/2020]
             * You can catch multiple exceptions by chain the exception.
             * Be aware of put the general exception (Exception) at the very end.
             */
        }

        public void CustomException()
        {
            
        }
    }

    class AgeException : ApplicationException
    {
        public override string Message => "Age is not between 18 and 1000";
    }
}