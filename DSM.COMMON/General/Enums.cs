using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.COMMON.General
{
    public class Enums
    {
        public enum ScreenDirection
        {
            Veritical=0,
            Horizontal
        }
        public enum Animation
        {
            LeftToRight=0,
            RightToLeft=1,
            IsUP=2,
            IsDOWN=3,
            
        }
        public enum ScheduledAttribution
        {
            Direct = 0,
            Scheduled
        }
        public enum mediaType
        {
            Image = 0,
            Video
        }
    }
}
