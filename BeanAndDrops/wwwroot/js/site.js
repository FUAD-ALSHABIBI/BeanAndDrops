// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    //Get Category and send to layout
    $.ajax({
        url: '/Category/GetCategory',
        success: function (i, j) {
            var List = $("#ListCate");
            if (i != null) {
                for (j = 0; j < i.length; j++) {
                    var item = JSON.parse(i[j]);
                    List.append('<li class="nav-item"> <a style="text-decoration:none;" class="nav-link active" aria-current="page" href="/cate/' + item.id + '">' + item.name + '</a> </li > ');
                }
            }
        }
    });

    //Show Count of Product and Total price
    $.ajax({
        url: '/Product/getCartDetails',
        success: function (i, j) {
            var p = $("#TotalProduct");
            var m = $("#TotalPrice");
            if (i != null) {
                p.text(i.length + " Products");
                var sum = 0;
                for (j = 0; j < i.length; j++) {
                    sum += JSON.parse(i[j]).price;
                }

                m.text(sum + " SAR");
            }
        }
    }); 
});

$("#searchPro").keypress(function () {
    $("#results").html('');
    $.ajax({
        url: '/Home/SearchProducts',
        data: { product: $(this).val() },
        success: function (i, j) {
            for (k = 0; k < i.length; k++) { 
                $("#results").append('<li class="list-group-item"<img src="' + i[k].image
                    + '" height="40" width="40" class="img-thumbnail" />  <a href="/products/' + i[k].product_id +'">'
                    + i[k].product_Name +'</a> </li>');
            }
        }
    });
});

$("#searchPro").blur(function () {
    if ($(this).val() == "") { 
     $("#results").html('');}
});
