using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social_Media_Service_Panel.Helper
{
    public class Platform
    {
        public bool is_touch { get; set; }
        public string app_platform { get; set; }
    }

    public class Relationship
    {
        public bool incoming_request { get; set; }
        public bool followed_by { get; set; }
        public bool outgoing_request { get; set; }
        public bool following { get; set; }
        public bool blocking { get; set; }
        public bool is_private { get; set; }
        public bool anonymous { get; set; }
    }

    public class GetParams
    {
    }

    public class Comments
    {
        public int count { get; set; }
        public List<object> data { get; set; }
    }

    public class From
    {
        public string username { get; set; }
        public string profile_picture { get; set; }
        public string id { get; set; }
        public string full_name { get; set; }
    }

    public class Caption
    {
        public string created_time { get; set; }
        public string text { get; set; }
        public From from { get; set; }
        public string id { get; set; }
    }

    public class Datum
    {
        public string username { get; set; }
        public string profile_picture { get; set; }
        public string id { get; set; }
        public string full_name { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
        public List<Datum> data { get; set; }
    }

    public class LowResolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnail
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class StandardResolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Images
    {
        public LowResolution low_resolution { get; set; }
        public Thumbnail thumbnail { get; set; }
        public StandardResolution standard_resolution { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string website { get; set; }
        public string profile_picture { get; set; }
        public string full_name { get; set; }
        public string bio { get; set; }
        public string id { get; set; }
    }

    public class UserMedia
    {
        public bool can_delete_comments { get; set; }
        public object location { get; set; }
        public bool can_view_comments { get; set; }
        public Comments comments { get; set; }
        public string alt_media_url { get; set; }
        public Caption caption { get; set; }
        public string link { get; set; }
        public Likes likes { get; set; }
        public string created_time { get; set; }
        public Images images { get; set; }
        public string type { get; set; }
        public string id { get; set; }
        public User user { get; set; }
    }

    public class Counts
    {
        public int media { get; set; }
        public int followed_by { get; set; }
        public int follows { get; set; }
    }

    public class User2
    {
        public string username { get; set; }
        public string bio { get; set; }
        public string website { get; set; }
        public string profile_picture { get; set; }
        public string full_name { get; set; }
        public Counts counts { get; set; }
        public string id { get; set; }
    }

    public class UserProfile
    {
        public bool canSeePrerelease { get; set; }
        public Relationship relationship { get; set; }
        public object viewer { get; set; }
        public object countryBlockInfo { get; set; }
        public GetParams __get_params { get; set; }
        public string staticRoot { get; set; }
        public List<UserMedia> userMedia { get; set; }
        public bool isAdvertiser { get; set; }
        public string __query_string { get; set; }
        public bool onlyAds { get; set; }
        public bool prerelease { get; set; }
        public User2 user { get; set; }
        public bool moreAvailable { get; set; }
        public string __path { get; set; }
        public bool isStaff { get; set; }
    }

    public class EntryData
    {
        public List<UserProfile> UserProfile { get; set; }
    }

    public class Config
    {
        public object viewer { get; set; }
        public string csrf_token { get; set; }
    }

    public class InstagramUser
    {
        public string static_root { get; set; }
        public Platform platform { get; set; }
        public string hostname { get; set; }
        public EntryData entry_data { get; set; }
        public string country_code { get; set; }
        public Config config { get; set; }
    }
}
