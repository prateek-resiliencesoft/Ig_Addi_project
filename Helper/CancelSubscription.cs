using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Helper
{

    public class CancelMetadata
    {
    }

    public class CancelPlan
    {
        public string interval { get; set; }
        public string name { get; set; }
        public int created { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public string @object { get; set; }
        public bool livemode { get; set; }
        public int interval_count { get; set; }
        public int trial_period_days { get; set; }
        public CancelMetadata metadata { get; set; }
        public object statement_descriptor { get; set; }
        public object statement_description { get; set; }
    }

    public class CancelMetadata2
    {
    }

    public class CancelSubscription
    {
        public string id { get; set; }
        public CancelPlan plan { get; set; }
        public string @object { get; set; }
        public int start { get; set; }
        public string status { get; set; }
        public string customer { get; set; }
        public bool cancel_at_period_end { get; set; }
        public int current_period_start { get; set; }
        public int current_period_end { get; set; }
        public int ended_at { get; set; }
        public int trial_start { get; set; }
        public int trial_end { get; set; }
        public int canceled_at { get; set; }
        public int quantity { get; set; }
        public object application_fee_percent { get; set; }
        public object discount { get; set; }
        public object tax_percent { get; set; }
        public CancelMetadata2 metadata { get; set; }
    }
}