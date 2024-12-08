using System;

namespace NetMvc.Cms.Common.Class
{
    public class BooleanDto 
    {
        public BooleanDto()
        {
            Value = false;
            // HasValue = false;
        }

        public BooleanDto(Boolean? value)
        {

            if (value == null)
            {
                // HasValue = false;
                Value = false;
            }
            else
            {
                // HasValue = true;
                Value = true;
            }

        }
        public Boolean Value { get; set; }
        // public Boolean HasValue { get; set; }
    }
}
