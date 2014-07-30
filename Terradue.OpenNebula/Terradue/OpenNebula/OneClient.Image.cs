//
//  OneClient.Image.cs
//
//  Author:
//       Enguerran Boissier <enguerran.boissier@terradue.com>
//
//  Copyright (c) 2014 Terradue

using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {
    /// <summary>
    /// DotNet4One Client calling XML-RPC requests exposed by an OpenNebula server.
    /// XML-RPC commands for Image.
    /// </summary>
    public partial class OneClient {

        /// <summary>
        /// Allocates the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="atributeValueTemplate">Atribute value template.</param>
        /// <param name="dataStoreId">Data store identifier.</param>
        public int ImageAllocate(string atributeValueTemplate, int dataStoreId){
            int result = 0;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageAllocate(this.SessionSHA, atributeValueTemplate, dataStoreId);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Clones the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="name">Name.</param>
        public int ImageClone(int id, string name){
            int result = 0;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageClone(this.SessionSHA, id, name);
            result = (int)openNebulaReturnArr.GetValue(1);
            return result;
        }

        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <returns><c>true</c>, if image was deleted, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        public bool ImageDelete(int id){
            bool result = false;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageDelete(this.SessionSHA, id);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Enables or diasbles the image.
        /// </summary>
        /// <returns><c>true</c>, if image was enabled, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        public bool ImageEnable(int id, bool enable){
            bool result = false;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageEnable(this.SessionSHA, id, enable);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Makes the image persistent.
        /// </summary>
        /// <returns><c>true</c>, if persistent image was made, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="persistent">If set to <c>true</c> persistent.</param>
        public bool ImageMakePersistent(int id, bool persistent){
            bool result = false;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImagePersistent(this.SessionSHA, id, persistent);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Changes the type of the image.
        /// </summary>
        /// <returns><c>true</c>, if image type was changed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="imageType">Image type.</param>
        public bool ImageChangeType(int id, string imageType){
            bool result = false;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageChangeType(this.SessionSHA, id, imageType);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Updates the image.
        /// </summary>
        /// <returns><c>true</c>, if image was updated, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newImageTemplate">New image template.</param>
        public bool ImageUpdate(int id, string newImageTemplate){
            bool result = false;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageUpdate(this.SessionSHA, id, newImageTemplate);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Changes image permissions
        /// </summary>
        /// <returns><c>true</c>, if image permissions was changed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="userUse">User use.</param>
        /// <param name="userManage">User manage.</param>
        /// <param name="userAdmin">User admin.</param>
        /// <param name="groupUse">Group use.</param>
        /// <param name="groupManage">Group manage.</param>
        /// <param name="groupAdmin">Group admin.</param>
        /// <param name="otherUse">Other use.</param>
        /// <param name="otherManage">Other manage.</param>
        /// <param name="otherAdmin">Other admin.</param>
        public bool ImageChmod(int id, int userUse, int userManage, int userAdmin, int groupUse, int groupManage, int groupAdmin, int otherUse, int otherManage, int otherAdmin){
            bool result = false;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageChangeMod(this.SessionSHA, id, userUse, userManage, userAdmin, groupUse, groupManage, groupAdmin, otherUse, otherManage, otherAdmin);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Changes the owner of the image
        /// </summary>
        /// <returns><c>true</c>, if image owner was changed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="imageId">Image identifier.</param>
        /// <param name="newOwnerId">New owner identifier.</param>
        /// <param name="newGroupId">New group identifier.</param>
        public bool ImageChown(int id, int imageId, int newOwnerId, int newGroupId){
            bool result = false;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageChangeOwner(this.SessionSHA, id, newOwnerId, newGroupId);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Renames the image.
        /// </summary>
        /// <returns><c>true</c>, if image was renamed, <c>false</c> otherwise.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="newName">New name.</param>
        public bool ImageRename(int id, string newName){
            bool result = false;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageRename(this.SessionSHA, id, newName);
            result = (bool)openNebulaReturnArr.GetValue(0);
            return result;
        }

        /// <summary>
        /// Gets the image info.
        /// </summary>
        /// <returns>The image info.</returns>
        /// <param name="id">Identifier.</param>
        public IMAGE ImageGetInfo(int id){
            IMAGE result = null;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImageInfo(this.SessionSHA, id);
            result = (IMAGE)Deserialize(typeof(IMAGE), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }


        /// <summary>
        /// Gets the image list info.
        /// </summary>
        /// <returns>The image list info.</returns>
        /// <param name="templateFilterFlag">Template filter flag.</param>
        /// <param name="rangeStartId">Range start identifier.</param>
        /// <param name="rangeEndId">Range end identifier.</param>
        /// <param name="vmState">Vm state.</param>
        public IMAGE_POOL ImageGetPoolInfo(int imageFilterFlag, int rangeStartId, int rangeEndId){
            IMAGE_POOL result = null;
            XmlRpcImageManagement xrum = (XmlRpcImageManagement)GetProxy(typeof(XmlRpcImageManagement));
            Array openNebulaReturnArr = xrum.oneImagePoolInfo(this.SessionSHA, imageFilterFlag, rangeStartId, rangeEndId);
            result = (IMAGE_POOL)Deserialize(typeof(IMAGE_POOL), openNebulaReturnArr.GetValue(1).ToString());
            return result;
        }

    }
}

