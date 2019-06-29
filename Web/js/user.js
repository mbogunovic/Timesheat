$(document).ready(function () {
	$("button.delete").on("click",
		function () {
			var form = $(this).closest("form");
			$.post("/User/Delete", $(form).serialize(), function() {
				window.location.reload();
			});
		});
});