using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    /*
     * Inspired from OpenNebula-CSharp-Adapter (https://github.com/Neuralab/OpenNebula-CSharp-Adapter)
    */

    [XmlRpcUrl(Terradue.OpenNebula.Configuration.XMLRPC_SERVER)]
    public interface XmlRpcImageManagement : IXmlRpcProxy
    {

        [XmlRpcMethod("one.image.allocate")]
        Array oneImageAllocate(string sessionSHA, string atributeValueTemplate, int dataStoreId);

        /*Description: Allocates a new image in OpenNebula.
        
            IN   String  The session string.
            IN   String  A string containing the template of the image. Syntax can be the usual “attribute=value” or XML.
            IN   Int     The datastore ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The allocated resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.image.clone")]
        Array oneImageClone(string sessionSHA, int imageId, string newImageName);

        /*Description: Clones an existing image.

            IN   String  The session string.
            IN   Int     The ID of the image to be cloned.
            IN   String  Name for the new image.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The new image ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.image.delete")]
        Array oneImageDelete(string sessionSHA, int imageId);

        /*Description: Deletes the given image from the pool.

            IN   String  The session string.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.image.enable")]
        Array oneImageEnable(string sessionSHA, int imageId, bool enableImage);

        /*Description: Enables or disables an image.

            IN   String  The session string.
            IN   Int     The Image ID.
            IN   Boolean     True for enabling, false for disabling.
            OUT  Boolean     true or false whenever is successful or not.
            OUT  Int/String  The Image ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.image.persistent")]
        Array oneImagePersistent(string sessionSHA, int imageId, bool persistentImage);

        /*Description: Sets the Image as persistent or not persistent.

            IN   String  The session string.
            IN   Int     The Image ID.
            IN   Boolean     True for persistent, false for non-persisent.
            OUT  Boolean     true or false whenever is successful or not.
            OUT  Int/String  The Image ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.image.chtype")]
        Array oneImageChangeType(string sessionSHA, int imageId, string imageType);

        /*Description: Changes the type of an Image.

            IN   String  The session string.
            IN   Int     The Image ID.
            IN   String  New type for the Image. See the existing types in the Image template reference.
            OUT  Boolean     true or false whenever is successful or not.
            OUT  Int/String  The Image ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.image.update")]
        Array oneImageUpdate(string sessionSHA, int imageId, string newImageTemplate);

        /*Description: Replaces the image template contents.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  The new template contents. Syntax can be the usual “attribute=value” or XML.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.image.chmod")]
        Array oneImageChangeMod(string sessionSHA, int objectId, int userUse, int userManage, int userAdmin, int groupUse, int groupManage, int groupAdmin, int otherUse, int otherManage, int otherAdmin);

        /*Description: Changes the permission bits of an image.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     USER USE bit. If set to -1, it will not change.
            IN   Int     USER MANAGE bit. If set to -1, it will not change.
            IN   Int     USER ADMIN bit. If set to -1, it will not change.
            IN   Int     GROUP USE bit. If set to -1, it will not change.
            IN   Int     GROUP MANAGE bit. If set to -1, it will not change.
            IN   Int     GROUP ADMIN bit. If set to -1, it will not change.
            IN   Int     OTHER USE bit. If set to -1, it will not change.
            IN   Int     OTHER MANAGE bit. If set to -1, it will not change.
            IN   Int     OTHER ADMIN bit. If set to -1, it will not change.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.image.chown")]
        Array oneImageChangeOwner(string sessionSHA, int imageId, int newOwnerId, int newGroupId);

        /*Description: Changes the ownership of an image.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   Int     The User ID of the new owner. If set to -1, the owner is not changed.
            IN   Int     The Group ID of the new group. If set to -1, the group is not changed.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/


        [XmlRpcMethod("one.image.rename")]
        Array oneImageRename(string sessionSHA, int imageId, string newName);

        /*Description: Renames an image.

            IN  String  The session string.
            IN  Int     The object ID.
            IN  String  The new name.
            OUT Boolean     true or false whenever is successful or not
            OUT Int/String  The VM ID / The error string.
            OUT Int     Error code.*/


        [XmlRpcMethod("one.image.info")]
        Array oneImageInfo(string sessionSHA, int imageId);

        /*Description: Retrieves information for the image.

            IN   String  The session string.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.*/





        [XmlRpcMethod("one.imagepool.info")]
        Array oneImagePoolInfo(string sessionSHA, int imageFilterFlag, int startId, int endId);

        /*Description: Retrieves information for all or part of the images in the pool.

            IN   String  The session string.
            IN   Int     Filter flag
            - < = -3: Connected user's resources
            - -2: All resources
            - -1: Connected user's and his group's resources
            - > = 0: UID User's Resources
            IN   Int     Range start ID. Can be -1.
            IN   Int     Range end ID. Can be -1.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.
            The range can be used to retrieve a subset of the pool, from the 'start' to the 'end' ID. To retrieve the complete pool, use (-1, -1); to retrieve all the pool from a specific ID to the last one, use (<id>, -1), and to retrieve the first elements up to an ID, use (0, <id>).
             */


    }
}

