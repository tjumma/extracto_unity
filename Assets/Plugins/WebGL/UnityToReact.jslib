mergeInto(LibraryManager.library, {
  GameReady: function () {
    window.dispatchReactUnityEvent("GameReady");
  },
  InitPlayer: function (playerName) {
    window.dispatchReactUnityEvent("InitPlayerFromUnity", UTF8ToString(playerName));
  },
  StartNewRun: function () {
    window.dispatchReactUnityEvent("StartNewRunFromUnity");
  },
  FinishRun: function () {
    window.dispatchReactUnityEvent("FinishRunFromUnity");
  },
});