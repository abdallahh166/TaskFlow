$(document).ready(function() {
    // Handle login form submission
    $('#loginForm').on('submit', function(e) {
        e.preventDefault();
        
        const username = $('#username').val();
        const password = $('#password').val();
        
        const userData = {
            username: username,
            password: password
        };

        console.log('Login Data:', JSON.stringify(userData)); // Log the data being sent

        $.ajax({
            url: 'https://localhost:7145/api/User/login', // Replace with your backend URL
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(userData),
            success: function(response) {
                // Store JWT token in localStorage
                localStorage.setItem('token', response.token);
                window.location.href = 'tasks.html'; // Redirect to tasks page
            },
            error: function(xhr, status, error) {
                $('#errorMessage').text('Invalid username or password.');
                console.error('Login error:', xhr.responseText); // Log the error response
            }
        });
    });

    // Handle sign-up form submission
    $('#signupForm').on('submit', function(e) {
        e.preventDefault();
        
        const newUsername = $('#newUsername').val();
        const newEmail = $('#newEmail').val();
        const newPassword = $('#newPassword').val();
        
        const signupData = {
            username: newUsername,
            password: newPassword, // Ensure this field is included directly
            email: newEmail
        };

        console.log('Sign-Up Data:', JSON.stringify(signupData)); // Log the data being sent

        $.ajax({
            url: 'https://localhost:7145/api/Account/signup', // Ensure this is the correct endpoint
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(signupData),
            success: function(response) {
                alert('Sign-up successful! You can now log in.');
                $('#signupForm')[0].reset(); // Reset the form
                $('#login-tab').tab('show'); // Switch to login tab
            },
            error: function(xhr, status, error) {
                $('#signupErrorMessage').text('Sign-up failed. Please try again.');
                console.error('Sign-up error:', xhr.responseText); // Log the error response
            }
        });
    });

    // Tab navigation
    $('a[data-toggle="tab"]').on('click', function(e) {
        e.preventDefault();
        $(this).tab('show');
    });
});
