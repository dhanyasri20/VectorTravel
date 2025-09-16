// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Navbar scroll effect
$(window).on('scroll', function () {
    // We add the 'navbar-scrolled' class to the navbar when the page is scrolled more than 50px
    // On pages that are not the home page, the check for window.scrollY > 50 will usually be true immediately
    // or the class will be added so fast it appears to be there from the start.
    if ($(window).scrollTop() > 50) {
        $('.navbar').addClass('navbar-scrolled');
    } else {
        // This part is mainly for the homepage, to make the navbar transparent again when scrolled back to the top
        $('.navbar').removeClass('navbar-scrolled');
    }
});

// This makes sure the navbar style is correct on page load for non-homepage pages.
$(document).ready(function () {
    if (window.location.pathname !== '/') {
        $('.navbar').addClass('navbar-scrolled');
    }
}); 