function getWindowDimensions() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

function getBoundingClientRectByClass(className) {
    const element = document.getElementsByClassName(className)[0];
    return element.getBoundingClientRect();
};

function getBoundingClientRect(element){
    return element.getBoundingClientRect();
}

function setPosition(element, x, y) {
    element.style.left = x + "px";
    element.style.top = y + "px";
}

function addDocumentKeyDownHandler(object, methodName) {
    document.addEventListener('keydown', function (evt) {
        object.invokeMethodAsync(methodName, evt.ctrlKey, event.altKey, evt.key)
            .then(result => {
            })
            .catch(error => {
                console.log('Error calling C# method:', error);
            });
    });
}
