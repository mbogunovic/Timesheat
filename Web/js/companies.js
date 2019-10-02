$(document).ready(function () {
    $('[data-company-meals-list]').on('change', function () {
        const $companyMeals = $(this);
        const selectedIndex = $companyMeals.prop('selectedIndex');
        let companyMeal = '<li class="portion__price" data-company-meal="' + this[selectedIndex].text + '" data-company-meal-id="' + $companyMeals.val() + '">';
        companyMeal += '<span>' + this[selectedIndex].text + '</span>';
        companyMeal += '<input name="SelectedMeals[]" type="hidden" value="' + $companyMeals.val() + '"/>';
        companyMeal += '</li>';

        //insert meal object as dom element inside ul of company meals
        $companyMeals.closest('form').find('[data-company-meals]')[0].insertAdjacentHTML('beforeend', companyMeal);
        $(this[selectedIndex]).remove();
    });

    $(document).on('click', '[data-company-meal]', function () {
        let portionsOptions = $(this).closest('form').find('[data-company-meals-list]')[0];
        portionsOptions.insertAdjacentHTML('beforeend', '<option value="' + $(this).data('companyMealId') + '">' + $(this).data('companyMeal') + '</option>');
        $(this).remove();
    });
});