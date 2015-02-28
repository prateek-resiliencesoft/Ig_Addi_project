using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social_Media_Service_Panel.ForImage.Helper
{
    public class Platform
    {
        public bool is_touch { get; set; }
        public string app_platform { get; set; }
    }

    public class Viewer
    {
        public string username { get; set; }
        public bool is_advertiser { get; set; }
        public bool is_staff { get; set; }
        public int id { get; set; }
        public string profile_pic_url { get; set; }
        public bool can_see_all_comments { get; set; }
    }

    public class Usertags
    {
        public List<object> nodes { get; set; }
    }

    public class Comments
    {
        public List<object> nodes { get; set; }
    }

    public class User
    {
        public string username { get; set; }
        public string profile_pic_url { get; set; }
    }

    public class Node
    {
        public User user { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
        public bool viewer_has_liked { get; set; }
        public List<Node> nodes { get; set; }
    }

    public class Owner
    {
        public string username { get; set; }
        public bool requested_by_viewer { get; set; }
        public bool followed_by_viewer { get; set; }
        public string profile_pic_url { get; set; }
        public bool has_blocked_viewer { get; set; }
        public string id { get; set; }
        public bool is_private { get; set; }
    }

    public class Media
    {
        public bool caption_is_edited { get; set; }
        public string code { get; set; }
        public double date { get; set; }
        public string caption { get; set; }
        public Usertags usertags { get; set; }
        public Comments comments { get; set; }
        public bool shared_by_author { get; set; }
        public Likes likes { get; set; }
        public Owner owner { get; set; }
        public bool is_video { get; set; }
        public string id { get; set; }
        public string display_src { get; set; }
    }

    public class GetParams
    {
    }

    public class DesktopPPage
    {
        public bool canSeePrerelease { get; set; }
        public Viewer viewer { get; set; }
        public Media media { get; set; }
        public GetParams __get_params { get; set; }
        public string staticRoot { get; set; }
        public string __query_string { get; set; }
        public bool prerelease { get; set; }
        public string __path { get; set; }
        public string shortcode { get; set; }
    }

    public class EntryData
    {
        public List<DesktopPPage> DesktopPPage { get; set; }
    }

    public class Viewer2
    {
        public string username { get; set; }
        public string website { get; set; }
        public string profile_picture { get; set; }
        public string bio { get; set; }
        public bool is_advertiser { get; set; }
        public bool is_staff { get; set; }
        public string full_name { get; set; }
        public string id { get; set; }
    }

    public class Config
    {
        public Viewer2 viewer { get; set; }
        public string csrf_token { get; set; }
    }

    public class InstagramImageResult
    {
        public string static_root { get; set; }
        public Platform platform { get; set; }
        public string hostname { get; set; }
        public EntryData entry_data { get; set; }
        public string country_code { get; set; }
        public Config config { get; set; }
    }
}
