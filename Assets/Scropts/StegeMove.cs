//ライブラリの宣言->これからこの機能を使うよ
using UnityEngine;
using UnityEngine.InputSystem;

public class StegeMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //変数,関数
    //変数->int,string 値を格納するための箱
    //アクセス修飾子　＋　データ型(int,string,InputAction)　＋　変数名(num,name)
    private InputAction moveInput;

    //関数->void,return 処理をまとめて実行するための箱

    //目的(抽象的課題)：ステージを回転させること
    //手段(具体的課題)：ActionMapを使用してプレイヤーの入力を受け取る
    //　　受け取った入力を元にステージのRotationを変更する



    //Start->シーンのロード時(ゲームの開始時)に自動的に実行される関数

    //void:戻り値
    //Start:関数名
    //():引き数
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(moveInput.ReadValue<Vector2>());
        //A += B -> A = A + B
        //this.transform.localPosition -> このコードがアタッチされているオブジェクト
        //moveInput.ReadValue<Vector2>() ->(x,y,z=0)

        Vector3 rotation;
        float threshold = 0.2f;
        // Vector3 -> (x,y,z)
        //moveInput.ReadValue<Vector2>().x => X軸
        //moveInput.ReadValue<Vector2>().y => Z軸

        rotation = new Vector3(moveInput.ReadValue<Vector2>().y*threshold, 0, moveInput.ReadValue<Vector2>().x*threshold);

        this.transform.Rotate ( rotation );

        // this.transfrom.Rotate += (x,y);
        // X,Y += (x,y);
 
        //1.回転軸がおかしい

    }
}
