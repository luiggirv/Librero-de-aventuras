using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using LootLocker.LootLockerEnums;
using LootLocker.Requests;


// using LootLocker.Admin;
// using LootLocker.Admin.Requests;

//this is common between user and admin
namespace LootLocker
{
    [System.Serializable]
    public enum LootLockerHTTPMethod
    {
        GET = 0,
        POST = 1,
        DELETE = 2,
        PUT = 3,
        HEAD = 4,
        CREATE = 5,
        OPTIONS = 6,
        PATCH = 7,
        UPLOAD = 8 
    }

    /// <summary>
    /// All ServerAPI.SendRequest responses will invoke the callback using an instance of this class for easier handling in client code.
    /// </summary>
    [System.Serializable]
    public class LootLockerResponse
    {

        /// <summary>
        /// TRUE if http error OR server returns an error status
        /// </summary>
        public bool hasError;
        /// <summary>
        /// HTTP Status Code
        /// </summary>
        public int statusCode;
        /// <summary>
        /// Raw text response from the server
        /// <para>If hasError = true, this will contain the error message.</para>
        /// </summary>
        public string text;
        public bool success;


        public string Error;
        /// <summary>
        /// A texture downloaded in the webrequest, if applicable, otherwise this will be null.
        /// </summary>
        public Texture2D texture;
        /// <summary>
        /// inheritdoc added this because unity main thread excuting style cut the calling stack and make the event orphant seealso calling multiple events 
        /// of the same type makes use unable to identify each one
        /// </summary>
        public string EventId;

    }

    /// <summary>
    /// Construct a request to send to the server.
    /// </summary>
    [System.Serializable]
    public struct LootLockerServerRequest
    {
        public string endpoint;
        public LootLockerHTTPMethod httpMethod;
        public Dictionary<string, object> payload;
        public string jsonPayload;
        public byte[] upload;
        public string uploadName;
        public string uploadType;
        public LootLocker.LootLockerEnums.LootLockerCallerRole adminCall;
        public WWWForm form;
        /// <summary>
        /// Leave this null if you don't need custom headers
        /// </summary>
        public Dictionary<string, string> extraHeaders;
        /// <summary>
        /// Query parameters to append to the end of the request URI
        /// <para>Example: If you include a dictionary with a key of "page" and a value of "42" (as a string) then the url would become "https: //mydomain.com/endpoint?page=42"</para>
        /// </summary>
        public Dictionary<string, string> queryParams;
        public int retryCount;

        #region Make ServerRequest and call send (3 functions)

        public static void CallAPI(string endPoint, LootLockerHTTPMethod httpMethod, string body = null, Action<LootLockerResponse> onComplete = null, bool useAuthToken = true, LootLocker.LootLockerEnums.LootLockerCallerRole callerRole = LootLocker.LootLockerEnums.LootLockerCallerRole.User)
        {
#if UNITY_EDITOR
            LootLockerSDKManager.DebugMessage("Caller Type: " + callerRole.ToString());
#endif

            Dictionary<string, string> headers = new Dictionary<string, string>();

            if (useAuthToken)
            {
                headers = new Dictionary<string, string>();
                headers.Add(callerRole == LootLocker.LootLockerEnums.LootLockerCallerRole.Admin ? "x-auth-token" : "x-session-token", callerRole == LootLocker.LootLockerEnums.LootLockerCallerRole.Admin ? LootLockerConfig.current.adminToken : LootLockerConfig.current.token);
            }

            if (LootLockerConfig.current != null)
                headers.Add(LootLockerConfig.current.dateVersion.key, LootLockerConfig.current.dateVersion.value);

            LootLockerBaseServerAPI.I.SwitchURL(callerRole);

            new LootLockerServerRequest(endPoint, httpMethod, body, headers, callerRole: callerRole).Send((response) =>
             {
                 onComplete?.Invoke(response);
             });
        }

        public static void UploadFile(string endPoint, LootLockerHTTPMethod httpMethod, byte[] file, string fileName = "file", string fileContentType = "text/plain", Dictionary<string, string> body = null, Action<LootLockerResponse> onComplete = null, bool useAuthToken = true, LootLocker.LootLockerEnums.LootLockerCallerRole callerRole = LootLocker.LootLockerEnums.LootLockerCallerRole.User)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();

            if (useAuthToken)
            {
                headers = new Dictionary<string, string>();

                headers.Add(callerRole == LootLockerCallerRole.Admin ? "x-auth-token" : "x-session-token", LootLockerConfig.current.token);

            }

            LootLockerBaseServerAPI.I.SwitchURL(callerRole);

            new LootLockerServerRequest(endPoint, httpMethod, file, fileName, fileContentType, body, headers, callerRole: callerRole).Send((response) =>
               {
                   onComplete?.Invoke(response);
               });
        }
        #endregion

        #region ServerRequest constructor
        public LootLockerServerRequest(string endpoint, LootLockerHTTPMethod httpMethod = LootLockerHTTPMethod.GET, byte[] upload = null, string uploadName = null, string uploadType = null, Dictionary<string, string> body = null, Dictionary<string, string> extraHeaders = null, bool useAuthToken = true, LootLocker.LootLockerEnums.LootLockerCallerRole callerRole = LootLocker.LootLockerEnums.LootLockerCallerRole.User, bool isFileUpload = true)
        {
            this.retryCount = 0;
            this.endpoint = endpoint;
            this.httpMethod = httpMethod;
            this.payload = null;
            this.upload = upload;
            this.uploadName = uploadName;
            this.uploadType = uploadType;
            this.jsonPayload = null;
            this.extraHeaders = extraHeaders != null && extraHeaders.Count == 0 ? null : extraHeaders; // Force extra headers to null if empty dictionary was supplied
            this.queryParams = null;
            this.adminCall = callerRole;
            this.form = new WWWForm();

            foreach (var kvp in body)
            {
                this.form.AddField(kvp.Key, kvp.Value);
            }

            this.form.AddBinaryData("file", upload, uploadName);

            bool isNonPayloadMethod = (this.httpMethod == LootLockerHTTPMethod.GET || this.httpMethod == LootLockerHTTPMethod.HEAD || this.httpMethod == LootLockerHTTPMethod.OPTIONS);

            if (this.payload != null && isNonPayloadMethod)
            {
                LootLockerSDKManager.DebugMessage("WARNING: Payloads should not be sent in GET, HEAD, OPTIONS, requests. Attempted to send a payload to: " + this.httpMethod.ToString() + " " + this.endpoint);
            }
        }

        public LootLockerServerRequest(string endpoint, LootLockerHTTPMethod httpMethod = LootLockerHTTPMethod.GET, Dictionary<string, object> payload = null, Dictionary<string, string> extraHeaders = null, Dictionary<string, string> queryParams = null, bool useAuthToken = true, LootLocker.LootLockerEnums.LootLockerCallerRole callerRole = LootLocker.LootLockerEnums.LootLockerCallerRole.User)
        {
            this.retryCount = 0;
            this.endpoint = endpoint;
            this.httpMethod = httpMethod;
            this.payload = payload != null && payload.Count == 0 ? null : payload; //Force payload to null if an empty dictionary was supplied
            this.upload = null;
            this.uploadName = null;
            this.uploadType = null;
            this.jsonPayload = null;
            this.extraHeaders = extraHeaders != null && extraHeaders.Count == 0 ? null : extraHeaders; // Force extra headers to null if empty dictionary was supplied
            this.queryParams = queryParams != null && queryParams.Count == 0 ? null : queryParams;
            this.adminCall = callerRole;
            bool isNonPayloadMethod = (this.httpMethod == LootLockerHTTPMethod.GET || this.httpMethod == LootLockerHTTPMethod.HEAD || this.httpMethod == LootLockerHTTPMethod.OPTIONS);
            this.form = null;
            if (this.payload != null && isNonPayloadMethod)
            {
                LootLockerSDKManager.DebugMessage("WARNING: Payloads should not be sent in GET, HEAD, OPTIONS, requests. Attempted to send a payload to: " + this.httpMethod.ToString() + " " + this.endpoint);
            }
        }
        public LootLockerServerRequest(string endpoint, LootLockerHTTPMethod httpMethod = LootLockerHTTPMethod.GET, string payload = null, Dictionary<string, string> extraHeaders = null, Dictionary<string, string> queryParams = null, bool useAuthToken = true, LootLocker.LootLockerEnums.LootLockerCallerRole callerRole = LootLocker.LootLockerEnums.LootLockerCallerRole.User)
        {
            this.retryCount = 0;
            this.endpoint = endpoint;
            this.httpMethod = httpMethod;
            this.jsonPayload = payload;
            this.upload = null;
            this.uploadName = null;
            this.uploadType = null;
            this.payload = null;
            this.extraHeaders = extraHeaders != null && extraHeaders.Count == 0 ? null : extraHeaders; // Force extra headers to null if empty dictionary was supplied
            this.queryParams = queryParams != null && queryParams.Count == 0 ? null : queryParams;
            this.adminCall = callerRole;
            bool isNonPayloadMethod = (this.httpMethod == LootLockerHTTPMethod.GET || this.httpMethod == LootLockerHTTPMethod.HEAD || this.httpMethod == LootLockerHTTPMethod.OPTIONS);
            this.form = null;
            if (!string.IsNullOrEmpty(jsonPayload) && isNonPayloadMethod)
            {
                LootLockerSDKManager.DebugMessage("WARNING: Payloads should not be sent in GET, HEAD, OPTIONS, requests. Attempted to send a payload to: " + this.httpMethod.ToString() + " " + this.endpoint);
            }
        }
        #endregion

        /// <summary>
        /// just debug and call ServerAPI.SendRequest which takes the current ServerRequest and pass this response
        /// </summary>
        public void Send(System.Action<LootLockerResponse> OnServerResponse)
        {
            LootLockerBaseServerAPI.I.SendRequest(this, (response) =>
            {
                OnServerResponse?.Invoke(response);
            });
        }
    }
}
