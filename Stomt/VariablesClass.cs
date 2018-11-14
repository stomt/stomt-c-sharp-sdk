using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Copyright © 2018+ Yiannis Panakos.
/// Creation Date: 20/08/2018, Update Date: 12/10/2018.
/// </summary>

namespace Stomt
{
    //class VariablesClass
    //{
    //}

    public class Constant
    {
        // Json tags.
        public const string publ_cs_parameter_prefix = "?";
        public const string publ_cs_required_parameter_prefix = "&";
        public const string publ_cs_parameter_suffix = "=";
        public const string publ_cs_child_value_open_tag = "{";
        public const string publ_cs_child_value_close_tag = "}";
        public const string publ_cs_child_array_value_open_tag = "[";
        public const string publ_cs_child_array_value_close_tag = "]";

        // Error messages.
        public const string publ_cs_generic_error = "error";
        public const string publ_cs_generic_no_data_message = "No Data!";
        public const string publ_cs_generic_success_message = "OK!";
        public const string publ_cs_generic_no_application_id_message = "No application id!";
    }
}
