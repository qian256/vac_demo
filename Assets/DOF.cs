using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DOF : MonoBehaviour {
    private Text text;
    public DepthTuner dt; 

    void Awake() {
        text = GetComponent<Text>();
    }

    void LateUpdate() {
        text.text = "DOF: " + dt.getCurrentDOF();
    }
}
