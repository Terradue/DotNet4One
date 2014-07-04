using System;
using CookComputing.XmlRpc;

namespace Terradue.OpenNebula {

    /*
     * Inspired from OpenNebula-CSharp-Adapter (https://github.com/Neuralab/OpenNebula-CSharp-Adapter)
    */

    [XmlRpcUrl(Terradue.OpenNebula.Configuration.XMLRPC_SERVER)]
    public interface XmlRpcVirtualNetworkManagement : IXmlRpcProxy
    {

        [XmlRpcMethod("one.vn.addleases")]
        Array oneVirtualNetworkAddLeases(string sessionSHA, int objectId, string addLeaseTemplate);

        /*Description:  Adds a new lease to the virtual network. Only available for FIXED networks.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  template of the lease to add. Syntax can be the usual “attribute=value” or XML, see below.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/

        /*
        LEASES=[IP=192.168.0.5]

            LEASES=[IP=192.168.0.5, MAC=50:20:20:20:20:20]

            <TEMPLATE>
            <LEASES>
            <IP>192.168.0.5</IP>
            </LEASES>
            </TEMPLATE>

            <TEMPLATE>
            <LEASES>
            <IP>192.168.0.5</IP>
            <MAC>MAC=50:20:20:20:20:20</MAC>
            </LEASES>
            </TEMPLATE>
            */




            [XmlRpcMethod("one.vn.hold")]
            Array oneVirtualNetworkHold(string sessionSHA, int objectId, string holdTemplate);

        /*Description:  Holds a virtual network Lease as used.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  template of the lease to remove. Syntax can be the usual “attribute=value” or XML, see one.vn.addleases.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vn.release")]
        Array oneVirtualNetworkRelease(string sessionSHA, int objectId, string releaseTemplate);

        /*Description:  Releases a virtual network Lease on hold.

            IN   String  The session string.
            IN   Int     The object ID.
            IN   String  template of the lease to release, e.g. “LEASES=[IP=192.168.0.5]”.
            OUT  Boolean     true or false whenever is successful or not
            OUT  Int/String  The resource ID / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vn.info")]
        Array oneVirtualNetworkInfo(string sessionSHA, int objectId);

        /*Description:  Retrieves information for the virtual network.

            IN   String  The session string.
            IN   Int     The object ID.
            OUT  Boolean     true or false whenever is successful or not
            OUT  String  The information string / The error string.
            OUT  Int     Error code.*/




        [XmlRpcMethod("one.vnpool.info")]
        Array oneVirtualNetworkPoolInfo(string sessionSHA, int filterFlag, int rangeStartId, int rangeEndId);

        /*Description:  Retrieves information for all or part of the virtual networks in the pool.

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
            OUT  Int     Error code.*/


        /* ----- NOT YET IMPLEMENTED ----- 

        one.vn.rmleases
        one.vn.update
        one.vn.allocate
        one.vn.delete
        one.vn.chown
        one.vn.chmod
        one.vn.rename

        */
    }
}

