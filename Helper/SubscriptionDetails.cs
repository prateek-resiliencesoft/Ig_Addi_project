using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialPanel.Helper
{
    public class Metadata
    {
    }

    public class Metadata2
    {
    }

    public class Plan
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
        public object trial_period_days { get; set; }
        public Metadata2 metadata { get; set; }
        public object statement_descriptor { get; set; }
    }

    public class Metadata3
    {
    }

    public class Datum
    {
        public string id { get; set; }
        public Plan plan { get; set; }
        public string @object { get; set; }
        public int start { get; set; }
        public string status { get; set; }
        public string customer { get; set; }
        public bool cancel_at_period_end { get; set; }
        public int current_period_start { get; set; }
        public int current_period_end { get; set; }
        public object ended_at { get; set; }
        public object trial_start { get; set; }
        public object trial_end { get; set; }
        public object canceled_at { get; set; }
        public int quantity { get; set; }
        public object application_fee_percent { get; set; }
        public object discount { get; set; }
        public object tax_percent { get; set; }
        public Metadata3 metadata { get; set; }
    }

    public class Subscriptions
    {
        public string @object { get; set; }
        public int total_count { get; set; }
        public bool has_more { get; set; }
        public string url { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Metadata4
    {
    }

    public class Datum2
    {
        public string id { get; set; }
        public string @object { get; set; }
        public string last4 { get; set; }
        public string brand { get; set; }
        public string funding { get; set; }
        public int exp_month { get; set; }
        public int exp_year { get; set; }
        public string fingerprint { get; set; }
        public string country { get; set; }
        public object name { get; set; }
        public object address_line1 { get; set; }
        public object address_line2 { get; set; }
        public object address_city { get; set; }
        public object address_state { get; set; }
        public object address_zip { get; set; }
        public object address_country { get; set; }
        public string cvc_check { get; set; }
        public object address_line1_check { get; set; }
        public object address_zip_check { get; set; }
        public object dynamic_last4 { get; set; }
        public Metadata4 metadata { get; set; }
        public string customer { get; set; }
    }

    public class Sources
    {
        public string @object { get; set; }
        public int total_count { get; set; }
        public bool has_more { get; set; }
        public string url { get; set; }
        public List<Datum2> data { get; set; }
    }

    public class SubscriptionDetails
    {
        public string @object { get; set; }
        public int created { get; set; }
        public string id { get; set; }
        public bool livemode { get; set; }
        public object description { get; set; }
        public object email { get; set; }
        public bool delinquent { get; set; }
        public Metadata metadata { get; set; }
        public Subscriptions subscriptions { get; set; }
        public object discount { get; set; }
        public int account_balance { get; set; }
        public string currency { get; set; }
        public Sources sources { get; set; }
        public string default_source { get; set; }
    }
    
}