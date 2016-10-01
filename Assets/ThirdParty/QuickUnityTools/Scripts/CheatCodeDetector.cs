﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public abstract class CheatCodeDetector : MonoBehaviour {

    private class Cheat {
        private string cheatCode;
        private Action onActivate;
        private int cheatTypeIndex;

        public Cheat(string cheatCode, Action onActivate) {
            this.cheatCode = cheatCode;
            this.onActivate = onActivate;
            this.cheatTypeIndex = 0;
        }

        public void Update() {
            if (Input.inputString != "") {
                if (Input.inputString[0] == this.cheatCode[this.cheatTypeIndex]) {
                    this.cheatTypeIndex++;
                    if (this.cheatTypeIndex == this.cheatCode.Length) {
                        this.onActivate();
                        this.cheatTypeIndex = 0;
                    }
                } else {
                    this.cheatTypeIndex = 0;
                }
            }
        }
    }

    private List<Cheat> cheats = new List<Cheat>();

    protected void Update() {
        foreach (Cheat cheat in this.cheats) {
            cheat.Update();
        }
    }

    public void RegisterCheat(string cheatCode, Action onActivate) {
        this.cheats.Add(new Cheat(cheatCode, onActivate));
    }
}