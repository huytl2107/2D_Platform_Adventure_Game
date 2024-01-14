using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerGotHitState : PlayerBaseState
{
    [SerializeField] private float _gotHitTime = .5f;
    private bool _isGottingHit = false;

    public PlayerGotHitState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public bool IsGottingHit { get => _isGottingHit; set => _isGottingHit = value; }

    public override void EnterState()
    {
        //Trừ máu Player ngay khi vào GotHitState rồi mới check If Else
        PlayerHealthController.Instane.GotHit();
        if (PlayerHealthController.Instane.PlayerHealth >= 0)
        {
            player.GotHitSound.Play();
            //Transition từ AnyState, tắt Can transition to self để không treo ở frame đàu.
            player.Anim.SetBool("GotHit", true);
            player.Rb.AddForce(Vector2.up * player.JumpForce, ForceMode2D.Impulse);
            player.StartCoroutine(GotHit());
            PlayerHealthController.Instane.UpdatePlayerHealthUI();
        }
        else
        {
            player.Anim.SetTrigger("Death");
            player.Rb.bodyType = RigidbodyType2D.Static;
            player.StartCoroutine(Death());
        }
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        player.Rb.velocity = new Vector2(-player.RaycastDirX * player.Speed, player.Rb.velocity.y);
    }


    public override void CheckSwitchState()
    {
        if (!IsGottingHit && PlayerHealthController.Instane.PlayerHealth >= 0)
        {
            SwitchState(factory.Fall());
        }
    }

    private IEnumerator GotHit()
    {
        IsGottingHit = true;
        yield return new WaitForSeconds(_gotHitTime);
        IsGottingHit = false;
    }

    private IEnumerator Death()
    {
        Debug.Log("Hello from IEnumerator");
        //Chờ 1s rồi restart level
        yield return new WaitForSeconds(1f);
        //Vì singleton không load lại nên cần trả máu Player về 3 trước khi restart level;
        PlayerHealthController.Instane.PlayerHealth = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public override void ExitState()
    {

    }
}
