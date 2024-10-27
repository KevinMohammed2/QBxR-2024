var WebGLBridge = {
  SaveScoreToLocalStorage: function (score) {
    // Convert the integer score to a string for localStorage
    localStorage.setItem("score", score.toString());

    // Dispatch a custom event to notify React of the update
    var event = new Event("scoreUpdated");
    window.dispatchEvent(event);
  },
};

mergeInto(LibraryManager.library, WebGLBridge);
