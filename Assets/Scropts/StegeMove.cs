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
    public float threshold = 0.2f;
    void Update()
    {
        Debug.Log(moveInput.ReadValue<Vector2>());
        //A += B -> A = A + B
        //this.transform.localPosition -> このコードがアタッチされているオブジェクト
        //moveInput.ReadValue<Vector2>() ->(x,y,z=0)

        Vector3 rotation;
       
        // Vector3 -> (x,y,z)
        //moveInput.ReadValue<Vector2>().x => X軸
        //moveInput.ReadValue<Vector2>().y => Z軸

        rotation = new Vector3(
        moveInput.ReadValue<Vector2>().y*threshold,
        0,
        moveInput.ReadValue<Vector2>().x*threshold);

        //this.transform.Rotate ( rotation );
        Quaternion tilt = Quaternion.Euler(rotation.x, 0f, rotation.z);
        this.gameObject.GetComponent<Rigidbody>().MoveRotation (
            this.gameObject.GetComponent<Rigidbody>().transform.rotation  * tilt
            );
        // this.transfrom.Rotate += (x,y);
        // X,Y += (x,y);


    }
}
//ゴール判定の作成
//1.IsTriggerの判定をコード上から取得
//2.すり抜けたらCanvasにゴールしたよ！とメッセージ表示
//(TexiMeshProで表示）