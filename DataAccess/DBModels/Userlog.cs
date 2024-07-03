using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Userlog
{
    public int Logid { get; set; }

    public int? Userid { get; set; }

    public DateTime? Datetime { get; set; }

    public string? Userip { get; set; }

    public string? Refererurl { get; set; }

    public string? Httprequestmethod { get; set; }

    public string? Httprequestquery { get; set; }

    public string? Requestedurl { get; set; }

    public string? Useragent { get; set; }

    public string? Browsername { get; set; }

    public string? Browserversion { get; set; }

    public int? Statuscode { get; set; }

    public int? Responsetime { get; set; }

    public string? Country { get; set; }

    public virtual User? User { get; set; }
}
