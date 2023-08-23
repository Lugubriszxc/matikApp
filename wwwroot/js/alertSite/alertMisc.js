
//functions that are called here doesn't return value 
    function alertError(message)
    {
        Swal.fire({
            icon: 'error',
            title: 'Error occured',
            text: message,
        })
    }

    //display success action
    function alertSuccess()
    {
        Swal.fire({
            icon: 'success',
            title: 'Your work has been saved', 
            showConfirmButton: false,
            timer: 1500
        })
    }

    