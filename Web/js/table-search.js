$(document).ready(function () {
	$(document).on("click", "[data-page], [data-letter], [data-btn-search]",
		function (e) {
			e.preventDefault();

			let kvp = document.location.search.substr(1).split('&');

			const page = $(this).data('page');
			if (page) {
				insertParam(kvp, 'page', page);
			}

			const letter = $(this).data('letter');
			if (letter) {
				kvp = [];
				if (!$(this).closest(".active").length) {
					insertParam(kvp, 'letter', letter);
				}
			}

			const query = $('[data-query]').val();
			insertParam(kvp, 'query', query);
			if (!query) {
				kvp.pop();
			}

			document.location.search = kvp.join('&');
		});

	$(document).on('keydown', "[data-query]",
		function (e) {
			if (e.keyCode == 13) {
				$('[data-btn-search').trigger('click');
			}
		});
	
	function insertParam(kvp, key, value) {
		key = encodeURI(key);
		value = encodeURI(value);


		var i = kvp.length; var x; while (i--) {
			x = kvp[i].split('=');

			if (x[0] == key) {
				x[1] = value;
				kvp[i] = x.join('=');
				break;
			}
		}

		if (i < 0) { kvp[kvp.length] = [key, value].join('='); }

		return kvp;
	}
});