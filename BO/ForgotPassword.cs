using System;
using System.Collections.Generic;

namespace BO;

public partial class ForgotPassword
{
    public int Fpid { get; set; }

    public DateTime ExpirationTime { get; set; }

    public int Otp { get; set; }

    public int Verified { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
