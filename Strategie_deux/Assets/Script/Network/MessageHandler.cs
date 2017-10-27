using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/*
 * Add New Player
 * List NetworkHash128
 * Move Unit
 * Add/Delete Unit
 * Add/Delete Building
 * Ressource
 * Syncronisation
 * Disconnect Player
 */

public class MessageServer : MessageBase
{
    public string Command;
    public string info;
}

public class MessageIdObject : MessageBase //msgServer + 0;
{
    public NetworkHash128 Command;
    public string info;
}

public class MessageListIdObject : MessageBase //msgServer + 0;
{
    public List<NetworkHash128> Command;
    public string info;
}

public class MessageRessource : MessageBase //msgServer + 1;
{
    public int Metal;
    public int Cristal;
    public int Gaz;
}

public class MessageUnit : MessageBase //msgServer + 2 or + 3;
{
    public Transform Position;
    public int IdUnit;
}

public class MessageHandler : MonoBehaviour {

    protected short msgServer = MsgType.Highest + 1;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    /*public MessageBase ListId(List<NetworkHash128> typeIdList) {
        MessageListIdObject msg = new MessageListIdObject();
        msg.Command = typeIdList;
        msg.info = "typeId";
        return msg;
    }*/

    public List<MessageBase> ListId(List<NetworkHash128> typeIdList)
    {
        List<MessageBase> listMsg = new List<MessageBase>();

        foreach (NetworkHash128 typeId in typeIdList)
        {
            MessageIdObject msg = new MessageIdObject();
            msg.Command = typeId;
            msg.info = "typeId";
            listMsg.Add(msg);
        }
        return listMsg;
    }
}
