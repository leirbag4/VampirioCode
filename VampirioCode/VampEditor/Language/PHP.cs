using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ScintillaNET;

namespace VampEditor.Language
{
    public class PHP : LanguageBase
    {
        // DATA from: https://www.w3schools.com/php/php_ref_array.asp
        public const string PHP_FUNCTIONS_MYSQL =               "mysql_affected_rows mysql_close mysql_connect mysql_create_db mysql_data_seek mysql_db_name mysql_db_query mysql_drop_db mysql_errno mysql_error mysql_escape_string mysql_fetch_array mysql_fetch_assoc mysql_fetch_field mysql_fetch_lengths mysql_fetch_object mysql_fetch_row mysql_field_flags mysql_field_len mysql_field_name mysql_field_seek mysql_field_table mysql_field_type mysql_free_result mysql_get_client_info mysql_get_host_info mysql_get_proto_info mysql_get_server_info mysql_change_user mysql_character_set_name mysql_info mysql_insert_id mysql_list_dbs mysql_list_fields mysql_list_processes mysql_list_tables mysql_num_fields mysql_num_rows mysql_pconnect mysql_ping mysql_query mysql_real_escape_string mysql_result mysql_select_db mysql_stat mysql_tablename mysql_thread_id mysql_unbuffered_query ";
        public const string PHP_FUNCTIONS_ARRAY =               "array array_change_key_case array_chunk array_column array_combine array_count_values array_diff array_diff_assoc array_diff_key array_diff_uassoc array_diff_ukey array_fill array_fill_keys array_filter array_flip array_intersect array_intersect_assoc array_intersect_key array_intersect_uassoc array_intersect_ukey array_key_exists array_keys array_map array_merge array_merge_recursive array_multisort array_pad array_pop array_product array_push array_rand array_reduce array_replace array_replace_recursive array_reverse array_search array_shift array_slice array_splice array_sum array_udiff array_udiff_assoc array_udiff_uassoc array_uintersect array_uintersect_assoc array_uintersect_uassoc array_unique array_unshift array_values array_walk array_walk_recursive arsort asort compact count current each end extract in_array key krsort ksort list natcasesort natsort next pos prev range reset rsort shuffle sizeof sort uasort uksort usort ";
        public const string PHP_FUNCTIONS_CALENDAR =            "cal_days_in_month cal_from_jd cal_info cal_to_jd easter_date easter_days frenchtojd gregoriantojd jddayofweek jdmonthname jdtofrench jdtogregorian jdtojewish jdtojulian jdtounix jewishtojd juliantojd unixtojd ";
        public const string PHP_FUNCTIONS_DATE =                "checkdate date_add date_create_from_format date_create date_date_set date_default_timezone_get date_default_timezone_set date_diff date_format date_get_last_errors date_interval_create_from_date_string date_interval_format date_isodate_set date_modify date_offset_get date_parse_from_format date_parse date_sub date_sun_info date_sunrise date_sunset date_time_set date_timestamp_get date_timestamp_set date_timezone_get date_timezone_set date getdate gettimeofday gmdate gmmktime gmstrftime idate localtime microtime mktime strftime strptime strtotime time timezone_abbreviations_list timezone_identifiers_list timezone_location_get timezone_name_from_abbr timezone_name_get timezone_offset_get timezone_open timezone_transitions_get timezone_version_get ";
        public const string PHP_FUNCTIONS_DIRECTORY =           "chdir chroot closedir dir getcwd opendir readdir rewinddir scandir ";
        public const string PHP_FUNCTIONS_ERROR =               "debug_backtrace debug_print_backtrace error_get_last error_log error_reporting restore_error_handler restore_exception_handler set_error_handler set_exception_handler trigger_error ";
        public const string PHP_FUNCTIONS_FILESYSTEM =          "basename chgrp chmod chown clearstatcache copy delete dirname disk_free_space disk_total_space diskfreespace fclose feof fflush fgetc fgetcsv fgets fgetss file file_exists file_get_contents file_put_contents fileatime filectime filegroup fileinode filemtime fileowner fileperms filesize filetype flock fnmatch fopen fpassthru fputcsv fputs fread fscanf fseek fstat ftell ftruncate fwrite glob is_dir is_executable is_file is_link is_readable is_uploaded_file is_writable is_writeable lchgrp lchown link linkinfo lstat mkdir move_uploaded_file parse_ini_file parse_ini_string pathinfo pclose popen readfile readlink realpath realpath_cache_get realpath_cache_size rename rewind rmdir set_file_buffer stat symlink tempnam tmpfile touch umask unlink ";
        public const string PHP_FUNCTIONS_FILTER =              "filter_has_var filter_id filter_input filter_input_array filter_list filter_var filter_var_array ";
        public const string PHP_FUNCTIONS_FTP =                 "ftp_alloc ftp_cdup ftp_chdir ftp_chmod ftp_close ftp_connect ftp_delete ftp_exec ftp_fget ftp_fput ftp_get ftp_get_option ftp_login ftp_mdtm ftp_mkdir ftp_mlsd ftp_nb_continue ftp_nb_fget ftp_nb_fput ftp_nb_get ftp_nb_put ftp_nlist ftp_pasv ftp_put ftp_pwd ftp_quit ftp_raw ftp_rawlist ftp_rename ftp_rmdir ftp_set_option ftp_site ftp_size ftp_ssl_connect ftp_systype ";
        public const string PHP_FUNCTIONS_JSON =                "json_decode json_encode ";
        public const string PHP_FUNCTIONS_LIBXML =              "libxml_clear_errors libxml_disable_entity_loader libxml_get_errors libxml_get_last_error libxml_set_external_entity_loader libxml_set_streams_context libxml_use_internal_errors ";
        public const string PHP_FUNCTIONS_MAIL =                "ezmlm_hash mail ";
        public const string PHP_FUNCTIONS_MATH =                "abs acos acosh asin asinh atan atan2 atanh base_convert bindec ceil cos cosh decbin dechex decoct deg2rad exp expm1 floor fmod getrandmax hexdec hypot intdiv is_finite is_infinite is_nan lcg_value log log10 log1p max min mt_getrandmax mt_rand mt_srand octdec pi pow rad2deg rand round sin sinh sqrt srand tan tanh ";
        public const string PHP_FUNCTIONS_MISC =                "connection_aborted connection_status connection_timeout constant define defined die eval exit get_browser __halt_compiler highlight_file highlight_string hrtime ignore_user_abort pack php_strip_whitespace show_source sleep sys_getloadavg time_nanosleep time_sleep_until uniqid unpack usleep ";
        public const string PHP_FUNCTIONS_MYSQLI =              "affected_rows autocommit change_user character_set_name close commit connect connect_errno connect_error data_seek debug dump_debug_info errno error error_list fetch_all fetch_array fetch_assoc fetch_field fetch_field_direct fetch_fields fetch_lengths fetch_object fetch_row field_count field_seek get_charset get_client_info get_client_stats get_client_version get_connection_stats get_host_info get_proto_info get_server_info get_server_version info init insert_id kill more_results multi_query next_result options ping poll prepare query real_connect real_escape_string real_query reap_async_query refresh rollback select_db set_charset set_local_infile_handler sqlstate ssl_set stat stmt_init thread_id thread_safe use_result warning_count ";
        public const string PHP_FUNCTIONS_NETWORK =             "checkdnsrr closelog dns_check_record dns_get_mx dns_get_record fsockopen gethostbyaddr gethostbyname gethostbynamel gethostname getmxrr getprotobyname getprotobynumber getservbyname getservbyport header_register_callback header_remove header headers_list headers_sent http_response_code inet_ntop inet_pton ip2long long2ip openlog pfsockopen setcookie setrawcookie socket_get_status socket_set_blocking socket_set_timeout syslog ";
        public const string PHP_FUNCTIONS_OUTPUT_CONTROL =      "flush ob_clean ob_end_clean ob_end_flush ob_flush ob_get_clean ob_get_contents ob_get_flush ob_get_length ob_get_level ob_gzhandler ob_implicit_flush ob_list_handlers ob_start output_add_rewrite_var output_reset_rewrite_vars ";
        public const string PHP_FUNCTIONS_REGEX =               "preg_filter preg_grep preg_last_error preg_match preg_match_all preg_replace preg_replace_callback preg_replace_callback_array preg_split preg_quote ";
        public const string PHP_FUNCTIONS_SIMPLE_XML =          "__construct() __tostring() addAttribute addChild asXML attributes children count getDocNamespaces getName getNamespaces registerXPathNamespace saveXML simplexml_import_dom simplexml_load_file simplexml_load_string xpath current getchildren haschildren key next rewind valid ";
        public const string PHP_FUNCTIONS_STRING =              "addcslashes addslashes bin2hex chop chr chunk_split convert_cyr_string convert_uudecode convert_uuencode count_chars crc32 crypt echo explode fprint get_html_translation_table hebrev hebrevc hex2bin html_entity_decode htmlentities htmlspecialchars_decode htmlspecialchars implode join lcfirst levenshtein localeconv ltrim md5 md5_file metaphone money_format nl_langinfo nl2br number_format ord parse_str print printf quoted_printable_decode quoted_printable_encode quotemeta rtrim setlocale sha1 sha1_file similar_text soundex sprintf sscanf str_getcsv str_ireplace str_pad str_repeat str_replace str_rot13 str_shuffle str_split str_word_count strcasecmp strchr strcmp strcoll strcspn strip_tags stripcslashes stripslashes stripos stristr strlen strnatcasecmp strnatcmp strncasecmp strncmp strpbrk strpos strrchr strrev strripos strrpos strspn strstr strtok strtolower strtoupper strtr substr substr_compare substr_count substr_replace trim ucfirst ucwords vfprintf vprintf vsprintf wordwrap ";
        public const string PHP_FUNCTIONS_VARIABLE_HANDLING =   "boolval debug_zval_dump doubleval is_countable empty floatval get_defined_vars get_resource_type gettype intval is_array is_bool is_callable is_double is_float is_int is_integer is_iterable is_long is_null is_numeric is_object is_real is_resource is_scalar is_string isset print_r serialize settype strval unserialize unset var_dump var_export ";
        public const string PHP_FUNCTIONS_XML_PARSER =          "utf8_decode utf8_encode xml_error_string xml_get_current_byte_index xml_get_current_column_number xml_get_current_line_number xml_get_error_code xml_parse xml_parse_into_struct xml_parser_create_ns xml_parser_create xml_parser_free xml_parser_get_option xml_parser_set_option xml_set_character_data_handler xml_set_default_handler xml_set_element_handler xml_set_end_namespace_decl_handler xml_set_external_entity_ref_handler xml_set_notation_decl_handler xml_set_object xml_set_processing_instruction_handler xml_set_start_namespace_decl_handler xml_set_unparsed_entity_decl_handler ";
        public const string PHP_FUNCTIONS_ZIP =                 "zip_close zip_entry_close zip_entry_compressedsize zip_entry_compressionmethod zip_entry_filesize zip_entry_name zip_entry_open zip_entry_read zip_open zip_read";


        public static string PHP_FUNCTIONS =        PHP_FUNCTIONS_MYSQL + PHP_FUNCTIONS_ARRAY + PHP_FUNCTIONS_CALENDAR + PHP_FUNCTIONS_DATE + PHP_FUNCTIONS_DIRECTORY + PHP_FUNCTIONS_ERROR + PHP_FUNCTIONS_FILESYSTEM + PHP_FUNCTIONS_FILTER + PHP_FUNCTIONS_FTP + PHP_FUNCTIONS_JSON + PHP_FUNCTIONS_LIBXML + PHP_FUNCTIONS_MAIL + PHP_FUNCTIONS_MATH + PHP_FUNCTIONS_MISC + PHP_FUNCTIONS_MYSQLI + PHP_FUNCTIONS_NETWORK + PHP_FUNCTIONS_OUTPUT_CONTROL + PHP_FUNCTIONS_REGEX + PHP_FUNCTIONS_SIMPLE_XML + PHP_FUNCTIONS_STRING + PHP_FUNCTIONS_VARIABLE_HANDLING + PHP_FUNCTIONS_XML_PARSER + PHP_FUNCTIONS_ZIP;
        //public static string PHP_COMMON_CLASSES =   "String Filesystem ArrayObject PDO mysqli SessionHandler DateTime SimpleXMLElement JSON ReflectionClass ReflectionMethod ReflectionFunction ReflectionParameter Exception Error SplFileObject SplFileInfo DirectoryIterator DateTimeZone DateInterval DatePeriod SimpleXMLIterator RecursiveIteratorIterator RecursiveArrayIterator ArrayIterator RegexIterator FilterIterator CallbackFilterIterator CachingIterator LimitIterator RecursiveDirectoryIterator PDOStatement PDOException PDOStatement SQLite3 SQLite3Stmt SQLite3Result SQLite3Exception SimpleXMLElement SoapClient SoapFault SoapHeader SoapParam SoapServer";
        public static string PHP_LANG_KEYWORDS =    "abstract and array as break callable case catch class clone const continue declare default do echo else elseif empty enddeclare endfor endforeach endif endswitch endwhile extends final finally for foreach function global goto if implements include include_once instanceof insteadof interface isset list namespace new or print private protected public require require_once return static switch throw trait try unset use var while xor yield ";


        private static List<String> PHP_EXTRA_CLASSES = new List<String>();

        protected override void OnActivate(StyleMode style)
        {

            if (style == StyleMode.Lite)
            {



            }
            else if (style == StyleMode.Dark)
            {

                editor.LexerName = "phpscript";

                //
                // This Should be before 'StyleClearAll' to work!!!
                //
                SetFontSyle();
                Styles[Style.Default].BackColor = CColor(39, 40, 34);

                // clear command
                editor.StyleClearAll();


                // Custom Style
                Styles[Style.PhpScript.Default].ForeColor =         CColor(179, 153, 255);  // default like MyFunc()
                Styles[Style.PhpScript.HString].ForeColor =         CColor(185, 255, 115);  // "hello php"
                Styles[Style.PhpScript.SimpleString].ForeColor =    CColor(200, 200, 130);  // 'hello php'
                Styles[Style.PhpScript.Word].ForeColor =            CColor(0, 0, 0);        // ------------->  [BUG: doesn't work!!!]
                Styles[Style.PhpScript.Number].ForeColor =          CColor(200, 100, 200);  // 1 20 300 1234
                Styles[Style.PhpScript.Variable].ForeColor =        CColor(255, 153, 153);  // $data $info
                Styles[Style.PhpScript.Comment].ForeColor =         CColor(0, 130, 50);     // /* comment */
                Styles[Style.PhpScript.CommentLine].ForeColor =     CColor(0, 130, 70);     // // comment
                Styles[Style.PhpScript.HStringVariable].ForeColor = CColor(255, 150, 110);  // "info is: $data ok" 
                Styles[Style.PhpScript.Operator].ForeColor =        CColor(157, 134, 191);  // -+()[].;=
                Styles[18].ForeColor =                              CColor(255, 90, 90);    // <?php  ?>
                Styles[121].ForeColor =                             CColor(122, 77, 255);    // if for switch <- AND ALSO -> echo mysql_result json_encode
                Styles[104].ForeColor =                             CColor(255, 0, 255);    //"{$new_var}"   -> SCE_HPHP_COMPLEX_VARIABLE




                string classes = "";

                for (int a = 0; a < PHP_EXTRA_CLASSES.Count; a++)
                    classes += PHP_EXTRA_CLASSES[a] + " ";


                editor.SetKeywords(4, PHP_LANG_KEYWORDS + PHP_FUNCTIONS);

                //
                // BUG: index 0 doesn't WORK!!!!!
                // 
                //     ->  editor.SetKeywords(0, PHP_LANG_KEYWORDS);
                //
                // and this Style DO NOTHING!!!
                //
                //     ->  Styles[Style.PhpScript.Word]
                //

                // editor.SetKeywords(0, PHP_LANG_KEYWORDS);



                SetFoldMarginStyle();
                EnableCodeFolding();
                SetSelctionStyle();
                SetLinesNumber(true, 40);
            }

        }
    }
}
