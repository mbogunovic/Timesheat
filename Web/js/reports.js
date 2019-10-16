$(document).ready(function () {
	$(".js-filter-reports").on("click",
		function (e) {
			e.preventDefault();
			let form = $(this).closest("form");
			$.ajax({
				url: "/report/filter",
				data: form.serialize(),
				success: function (data) {
					$(".js-report-results").html(data);
				},
				error: function(data) {
					console.error("an error occured");
				}
			});
		});
});