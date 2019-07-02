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

$(document).ready(function () {
    // bind on page load
    $(".js-company-meals").children().on("click",
        function(e) {
            bindClickRemove($(this), $(this).closest("form").find("select[name=MealList]", "mealid"));
        });
    $("select[name=MealList]").change(function (e) {
        var target = $(e.target); // select container
        var selectItem = $(this.selectedOptions[0]); // selected value
        if (!$(selectItem).val()) {
            return; // no value (placeholder), skip logic for this one
        }
        var currentForm = $(target).closest('form'); // containing form
        var selectedList = $(currentForm).find('.js-company-meals'); // get the ul with made selections
        // create the li element for made selections list
        var $element = createElement("<li>",
            {
                "data-mealid": $(selectItem).val()
            });
        $element.text($(selectItem).text());
        // add the created element
        appendElement(selectedList, $element);
        var selectedListItems = $(selectedList).children(); //all selected elements
        $(selectedListItems).off("click"); //invalidate old click
        // bind new click
        $(selectedListItems).on("click", function () {
            bindClickRemove($(this), $(currentForm).find("select[name=MealList]"), "mealid");
        });
        // create new comma separated values
        var newValue = "";
        for (var i = 0; i < selectedListItems.length; i++) {
            newValue += $(selectedListItems[i]).data("mealid") + ",";
        }
        newValue = newValue.substring(0, newValue.length - 1); //remove trailing comma
        setValue($(currentForm).find("[name=CompanyMealsIds]"), newValue); //set the new value to the element
        $(selectItem).remove(); //remove the element from options
    });
});