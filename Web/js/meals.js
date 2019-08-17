$(document).ready(function () {
    $('[data-portions-list]').on('change', function () {
        const $portionsOptions = $(this);
        const selectedIndex = $portionsOptions.prop('selectedIndex');
        let mealPortion = '<li class="portion__price" data-meal-portion="' + this[selectedIndex].text + '" data-meal-portion-id="' + $portionsOptions.val() + '">';
        mealPortion += '<span>' + this[selectedIndex].text + '</span>';
        mealPortion += '<input name="SelectedMealPortions[' + $portionsOptions.val() + ']" type="number" min="0" data-portion-price value="0"/>';
        mealPortion += '<span>Din.</span>'; 
        mealPortion += '</li>';

        //insert mealPortion object as dom element inside ul of meal portions
        $portionsOptions.closest('form').find('[data-meal-portions]')[0].insertAdjacentHTML('beforeend', mealPortion);
        $(this[selectedIndex]).remove();
    });

    $(document).on('click', '[data-meal-portion]', function () {
        let portionsOptions = $(this).closest('form').find('[data-portions-list]')[0];
        portionsOptions.insertAdjacentHTML('beforeend', '<option value="' + $(this).data('mealPortionId') + '">' + $(this).data('mealPortion') + '</option>');
        $(this).remove();
    });

    $(document).on('click', '[data-portion-price]', function (e) {
        e.stopPropagation();
    });
});