import Button from '@mui/material/Button'
import Stack from '@mui/material/Stack'
import TextField from '@mui/material/TextField'
import Typography from '@mui/material/Typography'
import React from 'react'
import { useForm } from 'react-hook-form'
import { Link, useNavigate } from 'react-router-dom'

export default function Login() {

  let {register,formState:{errors}, handleSubmit} = useForm();

  let onSubmit = (data:any) => {
    console.log(data);
  }

  let navigate = useNavigate()

  return (
    <Stack sx={{width:'70',margin:'auto'}}>
          <Typography variant="subtitle1">Welcome back!</Typography>
          <Typography variant='h5' sx={{marginBottom:'2rem'}}>Login to your account</Typography> 
          
          <form onSubmit={handleSubmit(onSubmit)}>
            <TextField {...register('email',{required:'This is rquired filed'})} type='email' fullWidth label="Email" id="fullWidth" sx={{marginBottom:'1rem'}}/>
            {errors.email && <Typography variant='body2' color='red'>{errors.email.message?.toString()}</Typography>}

            <TextField {...register('password',{required:'This is rquired filed'})} type='password' fullWidth label="Password" id="fullWidth" sx={{marginBottom:'1rem'}}/>
            {errors.password && <Typography variant='body2' color='red'>{errors.password.message?.toString()}</Typography>}

            <Button onClick={()=> navigate('/login')} variant="contained" fullWidth sx={{marginBottom:'1rem',backgroundColor:'#EF6B4A'}} >Login</Button>
            <Button type='submit' variant="outlined" fullWidth onClick={()=> navigate('/register')}>Register</Button>
          </form>
          
    </Stack>
  )
}
