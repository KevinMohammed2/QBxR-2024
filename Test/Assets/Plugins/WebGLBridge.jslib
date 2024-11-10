var WebGLBridge = {
  SendScores: function (difficulty1Score, difficulty2Score, difficulty3Score) {
    localStorage.setItem("score1", difficulty1Score.toString());
    localStorage.setItem("score2", difficulty2Score.toString());
    localStorage.setItem("score3", difficulty3Score.toString());


    var event = new Event("scoreUpdated");
    window.dispatchEvent(event);
  },
};

mergeInto(LibraryManager.library, WebGLBridge);
