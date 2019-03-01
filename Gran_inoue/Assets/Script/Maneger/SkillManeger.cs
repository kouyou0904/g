using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManeger : MonoBehaviour {
	[SerializeField]CharacterManeger _characterManeger = null;
    [SerializeField]Entity_Status _entitystatus = null;
    [SerializeField]PenguinStatus[] _penguinstatus = null;
    [SerializeField]FroideStatus _froidestatus = null;
	[SerializeField]SwiftStatus _sstatus = null;
	[SerializeField]GameObject _swiftset = null;


    bool PSkill = false;
	bool PSwiftMEISOU = false;
	bool PSwiftPowerUP = false;

	// Use this for initialization
	void Start () {
        _entitystatus = Resources.Load("Date/Status") as Entity_Status;
    }
	
	// Update is called once per frame
	void Update () {
        // Debug.Log("今の"+_entitystatus.param[0].HP);
        PenguinPowarUP();
  
	}

    public void PenguinPowarUP()
    {
        if (_froidestatus.FroideHP(0) <= _entitystatus.param[0].HP / 2 && _froidestatus.FroideHP(0) > 0 && !PSkill)
        {
            for (int i = 0; i < 4; i++)
            {
                _penguinstatus[i].PenguinMAXHP(20);
                _penguinstatus[i].PenguinHP(-20);
                _penguinstatus[i].PenguinAttack(10);
                _penguinstatus[i].PenguinDefance(5);
                _penguinstatus[i].PenguinMDefance(2);
                _penguinstatus[i].PenguinImpact(5);
                _penguinstatus[i].PenguinWeight(3);
            }

            PSkill = true;

            _characterManeger.PlayerPenguinSkill();
        }

    }

	public void PSwiftSkillofMEISOU() {

		if (!PSwiftMEISOU && _swiftset.activeInHierarchy) {
			_sstatus.SwiftAttack (-5);
			_sstatus.SwiftDefance (-5);
			_sstatus.SwiftMDefance (-5);
			_sstatus.SwiftImpact (-5);
			_sstatus.SwiftWeight (-5);

            _characterManeger.PlayerSwiftSkill();

            PSwiftPowerUP = false;
            PSwiftMEISOU = true;
		}
	}

	public void PSwiftSkillofPowerUP(){
		
		if (!PSwiftPowerUP && PSwiftMEISOU && _swiftset.activeInHierarchy) {
			_sstatus.SwiftAttack (7);
			_sstatus.SwiftDefance (7);
			_sstatus.SwiftMDefance (7);
			_sstatus.SwiftImpact (7);
			_sstatus.SwiftWeight (7);

            _characterManeger.PlayerSwiftStopSkill();

			PSwiftPowerUP = true;
			PSwiftMEISOU = false;
		}
	}

    public bool PSwiftSkillMEISOUSet()
    {
        return PSwiftMEISOU;
    }

    public bool PSwiftSkillPowerUPSet()
    {
        return PSwiftPowerUP;
    }

    public bool PSkillSet()
    {
        return PSkill;
    }
}
