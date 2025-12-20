import Button from '@mui/material/Button'
import InputLabel from '@mui/material/InputLabel'
import Stack from '@mui/material/Stack'
import TextField from '@mui/material/TextField'
import Typography from '@mui/material/Typography'
import React from 'react'
import { useForm } from 'react-hook-form'

export default function ChangePass() {
  let {register,formState:{errors}, handleSubmit} = useForm();

  let onSubmit = (data:any) => {
    console.log(data);
  }

  return (
    <Stack sx={{width:'70',margin:'auto'}}>
          <Typography variant="subtitle1">Welcome back!</Typography>
          <Typography variant='h5' sx={{marginBottom:'2rem'}}>Change Your Password Easily </Typography> 
          
          <form onSubmit={handleSubmit(onSubmit)}>
            <InputLabel id="demo-simple-select-label">Old Password</InputLabel>
            <TextField {...register('old',{required:'This is rquired filed'})} type='password' fullWidth sx={{marginBottom:'1rem'}}/>
            {errors.old && <Typography variant='body2' color='red'>{errors.old.message?.toString()}</Typography>}

            <InputLabel id="demo-simple-select-label">New Password</InputLabel>
            <TextField {...register('newpassword',{required:'This is rquired filed'})} type='password' fullWidth sx={{marginBottom:'1rem'}}/>
            {errors.newpassword && <Typography variant='body2' color='red'>{errors.newpassword.message?.toString()}</Typography>}

            <Button type='submit' variant="contained" fullWidth sx={{marginBottom:'1rem',backgroundColor:'#EF6B4A'}} >Save</Button>
          </form>
          
    </Stack>
  )
}
