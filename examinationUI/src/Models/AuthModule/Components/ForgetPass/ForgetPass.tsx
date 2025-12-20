import React from 'react'
import { useForm } from 'react-hook-form';
import Button from '@mui/material/Button'
import Stack from '@mui/material/Stack'
import TextField from '@mui/material/TextField'
import Typography from '@mui/material/Typography'

export default function ForgetPass() {

  let {register,formState:{errors}, handleSubmit} = useForm();
  
    let onSubmit = (data:any) => {
      console.log(data);
    }

  return (
    <Stack sx={{width:'70',margin:'auto'}}>
          <Typography variant="subtitle1">Welcome back!</Typography>
          <Typography variant='h5' sx={{marginBottom:'2rem'}}>Forget Password !!</Typography> 
          
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextField {...register('email',{required:'This is rquired filed'})} type='email' fullWidth label="Email" id="fullWidth" sx={{marginBottom:'1rem'}}/>
            {errors.email && <Typography variant='body2' color='red'>{errors.email.message?.toString()}</Typography>}
          
            <Button variant="outlined" fullWidth >Send</Button>
          </form>
          
    </Stack>
  )
}
