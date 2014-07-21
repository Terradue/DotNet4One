using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    public interface XmlRpcUserManagement : IXmlRpcProxy
    {
        [XmlRpcMethod("one.user.allocate")]
        Array oneUserAllocate(string sessionSHA, string username, string password, string authDriver);

        /*Description: Allocates a new user in OpenNebula
        
           IN    String  The session string.
           IN    String  username for the new user
           IN    String  password for the new user
           IN    String  authentication driver for the new user. If it is an empty string, then the default ('core') is used
           OUT   Boolean     true or false whenever is successful or not
           OUT   Int/String  The allocated User ID / The error string.
           OUT   Int     Error code.
        */


        [XmlRpcMethod("one.user.update")]
        Array oneUserUpdate(string sessionSHA, int userId, string newTemplate);

        /*Description: Replaces the user template contents.
        
           IN    String  The session string.
           IN    Int     The object ID.
           IN    String  The new template contents. Syntax can be the usual attribute=value or XML.
           IN    Int     Update type: 0: Replace the whole template. 1: Merge new template with the existing one.
           OUT   Boolean     true or false whenever is successful or not
           OUT   Int/String  The resource ID / The error string.
           OUT   Int     Error code.
        */


        [XmlRpcMethod("one.user.info")]
        Array oneUserInfo(string sessionSHA, int userId);

        /*Description: Retrieves information for the user.

            IN   String  The session string.
            IN   Int     The object ID. If it is -1, then the connected user's own info info is returned
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.
        */


        [XmlRpcMethod("one.user.delete")]
        Array oneUserDelete(string sessionSHA, int userId);

        /*Description: Deletes the given user from the pool.

            IN   String  The session string.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.
        */


        [XmlRpcMethod("one.user.passwd")]
        Array oneUserPassword(string sessionSHA, int userId, string newPassword);

        /*Description: Changes the password for the given user.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  The new password
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The User ID / The error string.
            OUT  Int     Error code.
        */


        [XmlRpcMethod("one.user.quota")]
        Array oneUserQuota(string sessionSHA, int userId, string atrributeValueContents);

        /*Description: Sets the user quota limits.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  The new quota template contents. Syntax can be the usual “attribute=value” or XML.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.
        */


        [XmlRpcMethod("one.user.chgrp")]
        Array oneUserChangeGroup(string sessionSHA, int userId, int newGroupId);

        /*Description: Changes the group of the given user.

            IN   String  The session string.
            IN   Int     The User ID.
            IN   Int     The Group ID of the new group.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The User ID / The error string.
            OUT  Int     Error code.
        */


        [XmlRpcMethod("one.user.addgroup")]
        Array oneUserAddGroup(string sessionSHA, int userId, int newGroupId);

        /*Description: Adds the User to a secondary group.

            IN  String  The session string.
            IN  Int     The User ID.
            IN  Int     The Group ID of the new group.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The User ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.user.delgroup")]
        Array oneUserDelGroup(string sessionSHA, int userId, int groupId);

        /*Description: Removes the User from a secondary group

            IN  String  The session string.
            IN  Int     The User ID.
            IN  Int     The Group ID.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The User ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.userpool.info")]
        Array oneUserPoolInfo(string sessionSHA);

        /*Description: Retrieves information for all the users in the pool.

            IN   String  The session string.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.
        */


        [XmlRpcMethod("one.user.chauth")]
        Array oneUserChauth(string sessionSHA, int userId, string newAuthDriver, string newPassword);

        /*Description: Changes the authentication driver and the password for the given user.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new authentication driver.
            IN  String  The new password. If it is an empty string, the password is not changed.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The User ID / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.userquota.info")]
        Array oneUserQuotaInfo(string sessionSHA);

        /*Description: Returns the default user quota limits.

            IN  String  The session string.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The quota template contents / The error string.
            OUT Int     Error code.
        */


        [XmlRpcMethod("one.userquota.update")]
        Array oneUserQuotaUpdate(string sessionSHA, string newQuotaTemplate);

        /*Description: Updates the default user quota limits.

            IN  String  The session string.
            IN  String  The new quota template contents. Syntax can be the usual attribute=value or XML.
            OUT Boolean     true or false whenever is successful or not
            OUT String  The quota template contents / The error string.
            OUT Int Error code.
        */

    }
}

