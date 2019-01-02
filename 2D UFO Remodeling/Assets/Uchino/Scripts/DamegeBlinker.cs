using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeBlinker {

    private SpriteRenderer spriteRenderer;
    private Color defalut;
    private float blinkInterval = 0.15f;
    private float alpha = 0.35f;            //透明になるときの透明度
    private Timer blinkTimer;
    private bool isBlink = false;
    private bool isBlinker = true;

    public DamegeBlinker(SpriteRenderer spriteRenderer)
    {
        this.spriteRenderer = spriteRenderer;
        defalut = spriteRenderer.color;
        blinkTimer = new Timer(1f);
    }

    /// <summary>
    /// 点滅
    /// </summary>
    public void BlinkStart()
    {
        isBlink = true;
    }

    public void BlinkUpdate()
    {
        //Blinkが始まってなければ実行しません
        if (!isBlink) return;

        blinkTimer.TimerUpdate();
        if (blinkTimer.IsTime())
        {
            isBlink = false;
            blinkTimer.Initialize();
            spriteRenderer.color = defalut;
            return;
        }

        Blink();
    }

    /// <summary>
    /// 点滅
    /// </summary>
    private void Blink()
    {
        //blinkintervalの3分の2秒毎にちかちかします
        if (blinkTimer.CurrentTime_Float % blinkInterval <= (blinkInterval * 2 / 3))
        {
            isBlinker = !isBlinker;
        }

        //透明にします。
        if (isBlinker)
        {
            ChangeAlpha();
            return;
        }

        //元に戻します。
        spriteRenderer.color = defalut;
    }

    private void ChangeAlpha()
    {
        spriteRenderer.color =
            new Color(defalut.r, defalut.g, defalut.b, alpha);

    }

}
 