$(document).ready(function() {
    const token = localStorage.getItem('token');

    if (!token) {
        window.location.href = 'index.html'; // Redirect to login if token is not present
        return;
    }

    fetchTasks(token);

    $('#addBtn').on('click', function() {
        addTask(token);
    });
});

function fetchTasks(token) {
    $.ajax({
        url: 'https://localhost:7145/api/task/tasks', // Replace with your backend URL
        type: 'GET',
        headers: {
            'Authorization': `Bearer ${token}`
        },
        success: function(response) {
            const tasksContainer = $('#tasksContainer');
            tasksContainer.empty(); // Clear previous tasks
            if (response.length === 0) {
                tasksContainer.append('<p>No tasks available.</p>');
            } else {
                response.forEach(task => {
                    tasksContainer.append(`
                        <div class="task card mb-3">
                            <div class="card-body">
                                <h4 class="card-title">${task.title}</h4>
                                <p class="card-text">${task.description || 'No description available'}</p>
                                <small class="text-muted">Created At: ${new Date(task.createdAt).toLocaleString()}</small>
                            </div>
                        </div>
                    `);
                });
            }
        },
        error: function(xhr, status, error) {
            console.error('Error fetching tasks:', status, error);
            console.error("Response:", xhr.responseText);
            alert('Failed to fetch tasks. Please try again.');
        }
    });
}

function addTask(token) {
    const taskTitle = $('#taskTitle').val();
    const taskDescription = $('#taskDescription').val();

    if (!taskTitle) {
        alert('Task title is required.');
        return;
    }

    const newTask = {
        title: taskTitle,
        description: taskDescription
    };

    $.ajax({
        url: 'https://localhost:7145/api/Task/create', // Replace with your backend URL
        type: 'POST',
        headers: {
            'Authorization': `Bearer ${token}`
        },
        contentType: 'application/json',
        data: JSON.stringify(newTask),
        success: function(response) {
            swal("Task Added!", `Title: ${newTask.title}\nDescription: ${newTask.description}`, "success", {
                buttons: false,
                timer: 2000
            });
            $('#addTaskForm')[0].reset(); // Reset the form
            $('#staticBackdrop').modal('hide'); // Hide the modal
            fetchTasks(token); // Refresh the task list
        },
        error: function(xhr, status, error) {
            console.error('Error adding task:', status, error);
            console.error("Response:", xhr.responseText);
            alert('Failed to add task. Please try again.');
        }
    });
}


