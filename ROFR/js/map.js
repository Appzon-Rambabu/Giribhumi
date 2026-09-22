jQuery(function ($) {

    $(".sidebar-dropdown > a").click(function() {
        if (
            $(this)
            .parent()
            .hasClass("active")
        ) {
            
            $(this)
            .next(".sidebar-submenu")
            .slideUp(200);

            $(this)
            .parent()
            .removeClass("active");

        } else {

            //$(".sidebar-dropdown").removeClass("active");
            $(this)
            .next(".sidebar-submenu")
            .slideDown(200);
            $(this)
            .parent()
            .addClass("active");
            
        }
    });

    $("#close-sidebar").click(function() {
        $(".page-wrapper").removeClass("toggled");
    });
    $("#show-sidebar").click(function() {
        $(".page-wrapper").addClass("toggled");
    });

    if (window.mobileAndTabletcheck){
        $(".page-wrapper").removeClass("toggled");        
    }
   
});

function checkActiveMenu(){
    $(".sidebar-dropdown > a").each(function() {
        if (
            $(this)
            .parent()
            .hasClass("active")
        ) {
            
            $(this)
            .next(".sidebar-submenu")
            .slideDown(200);

        } 
    });
}

$(document).ready(function(){
    setMapHeight();
    checkActiveMenu();
});

function setMapHeight(){
    try{
        var height = document.getElementById('navbar').offsetHeight;
        height = height+5;
    
        document.getElementById('app-main').style.height = `calc(100vh - ${height}px)`;
        document.getElementById('sidebar').style.height = `calc(100vh - ${height}px)`; 
    } catch { }
}
