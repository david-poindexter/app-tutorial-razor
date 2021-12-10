// The init function which should be called
function init() {
  // example element gets found in the DOM
  const exampleElement = document.querySelector("#turn-on-example")
  // success text gets displayed in the DOM
  exampleElement.innerText = "turnOn has been executed. 😉";
}

// For demo purpose, wait 3 seconds before we add the object and Init
// This should simulate slow loading of a JavaScript

setTimeout(() => {
  // Generate a new object if none exists yet (best practice)
  window.turnOnTutorial100 = window.turnOnTutorial100 || {};
  window.turnOnTutorial100.init = window.turnOnTutorial100.init || init;
}, 3000);

