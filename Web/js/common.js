function setValue(fieldSelector, newValue) {
    var field = $(fieldSelector);
    $(field).val(newValue);
}

function createElement(elementTag, elementAttributes) {
    return $(elementTag, elementAttributes);
}

function appendElement(container, element) {
    $(container).append(element);
}

function bindClickRemove(target, addSelectContainer, dataField) {
    var $element = createElement("<option>",
        {
            "value": $(target).data(dataField)
        });
    $element.text($(target).text());
    $(addSelectContainer).append($element);
    $(target).remove();
}

function updateHiddenField(selectedListItems, currentForm, dataAttr, fieldSelector) {
    // create new comma separated values
    var newValue = "";
    for (var i = 0; i < selectedListItems.length; i++) {
        newValue += $(selectedListItems[i]).data(dataAttr) + ",";
    }
    newValue = newValue.substring(0, newValue.length - 1); //remove trailing comma
    setValue($(currentForm).find(fieldSelector), newValue); //set the new value to the element
}