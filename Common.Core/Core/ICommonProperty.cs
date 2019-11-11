using System;

namespace Common.Core.Core
{
    public interface ICommonProperty
    {
         Guid CreateUserId { get; set; }
         DateTime CreateDate { get; set; }
         Guid? ModifyUserId { get; set; }
         DateTime? ModifyDate { get; set; }
    }
}
