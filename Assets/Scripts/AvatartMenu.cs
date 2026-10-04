using UnityEngine;
using UnityEngine.UI;

public class AvatartMenu : MonoBehaviour
{
    public PlayerAvatar p1Avatar;
    public PlayerAvatar p2Avatar;
    public Button p1Swap;
    public Button p2Swap;

    public GameObject avatarP1Parent;
    public GameObject avatartP2Parent;

    void Start()
    {
        p1Avatar = PlayerAvatar.Thimble;
        p2Avatar = PlayerAvatar.Car;

        p1Swap.onClick.AddListener(ChangeAvatarP1);
        p2Swap.onClick.AddListener(ChangeAvatarP2);

        UpdateAvatars();
    }

    public void ChangeAvatarP1()
    {
        if (p1Avatar == PlayerAvatar.Car && p2Avatar == PlayerAvatar.Hat)
        {
            p1Avatar = PlayerAvatar.Thimble;
        }
        else if (p1Avatar == PlayerAvatar.Car && p2Avatar == PlayerAvatar.Thimble)
        {
            p1Avatar = PlayerAvatar.Hat;
        }
        else if (p1Avatar == PlayerAvatar.Hat && p2Avatar == PlayerAvatar.Car)
        {
            p1Avatar = PlayerAvatar.Thimble;
        }
        else if (p1Avatar == PlayerAvatar.Hat && p2Avatar == PlayerAvatar.Thimble)
        {
            p1Avatar = PlayerAvatar.Car;
        }
        else if (p1Avatar == PlayerAvatar.Thimble && p2Avatar == PlayerAvatar.Car)
        {
            p1Avatar = PlayerAvatar.Hat;
        }
        else if (p1Avatar == PlayerAvatar.Thimble && p2Avatar == PlayerAvatar.Hat)
        {
            p1Avatar = PlayerAvatar.Car;
        }
        Debug.Log(p1Avatar);
        UpdateAvatars();
    }

    public void ChangeAvatarP2()
    {
        if (p2Avatar == PlayerAvatar.Car && p1Avatar == PlayerAvatar.Hat)
        {
            p2Avatar = PlayerAvatar.Thimble;
        }
        else if (p2Avatar == PlayerAvatar.Car && p1Avatar == PlayerAvatar.Thimble)
        {
            p2Avatar = PlayerAvatar.Hat;
        }
        else if (p2Avatar == PlayerAvatar.Hat && p1Avatar == PlayerAvatar.Car)
        {
            p2Avatar = PlayerAvatar.Thimble;
        }
        else if (p2Avatar == PlayerAvatar.Hat && p1Avatar == PlayerAvatar.Thimble)
        {
            p2Avatar = PlayerAvatar.Car;
        }
        else if (p2Avatar == PlayerAvatar.Thimble && p1Avatar == PlayerAvatar.Car)
        {
            p2Avatar = PlayerAvatar.Hat;
        }
        else if (p2Avatar == PlayerAvatar.Thimble && p1Avatar == PlayerAvatar.Hat)
        {
            p2Avatar = PlayerAvatar.Car;
        }

        Debug.Log(p2Avatar);
        UpdateAvatars();
    }

    public void UpdateAvatars()
    {
        foreach (Transform child in avatarP1Parent.transform)
        {
            if (child.GetComponent<PlayerAvatarMenu>().avatar == p1Avatar)
            {
                child.GetComponent<Image>().enabled = true;
            }
            else
            {
                child.GetComponent<Image>().enabled = false;
            }
        }

        foreach (Transform child in avatartP2Parent.transform)
        {
            if (child.GetComponent<PlayerAvatarMenu>().avatar == p2Avatar)
            {
                child.GetComponent<Image>().enabled = true;
            }
            else
            {
                child.GetComponent<Image>().enabled = false;
            }
        }
    }
}
