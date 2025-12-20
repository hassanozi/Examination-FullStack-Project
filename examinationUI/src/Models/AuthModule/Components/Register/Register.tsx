import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Grid from '@mui/material/Grid';
import Stack from '@mui/material/Stack';
import TextField from '@mui/material/TextField';
import Typography from '@mui/material/Typography';
import React from 'react'
import { useForm } from 'react-hook-form';
import InputLabel from '@mui/material/InputLabel';
import Select, { type SelectChangeEvent } from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';

export default function Register() {

  const [role, setRole] = React.useState('');

  const handleChange = (event: SelectChangeEvent) => {
    setRole(event.target.value as string);
  };

  let {register,formState:{errors}, handleSubmit} = useForm();
  
  let onSubmit = (data:any) => {
    console.log(data);
  }

  

  return (
        <Stack sx={{width:'70',margin:'auto'}}>
              <Typography variant="subtitle1">Create new acccount</Typography>
              <Typography variant='h5' sx={{marginBottom:'2rem'}}>Register</Typography> 
              
              <form onSubmit={handleSubmit(onSubmit)}>

                <Box sx={{ width: '100%' }}>
                  <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                    <Grid size={6}>
                      <Stack>
                        <InputLabel id="demo-simple-select-label">First Name</InputLabel>
                        <TextField {...register('firstName',{required:'This is rquired filed'})} type='text'  sx={{marginBottom:'1rem' }}/>
                       {errors.firstName && <Typography variant='body2' color='red'>{errors.firstName.message?.toString()}</Typography>}
                      </Stack>
                    </Grid>
                    <Grid size={6}>
                      <Stack>
                        <InputLabel id="demo-simple-select-label">Last Name</InputLabel>
                        <TextField {...register('lastName',{required:'This is rquired filed'})} type='text'    sx={{marginBottom:'1rem'}}/>
                        {errors.lastName && <Typography variant='body2' color='red'>{errors.lastName.message?.toString()}</Typography>}
                      </Stack>
                    </Grid>
                    
                  </Grid>
                </Box>
                
                <Box sx={{ width: '100%' }}>
                  <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
                    <Grid size={12}>
                      <Stack>
                        <InputLabel id="demo-simple-select-label">Email</InputLabel>
                        <TextField {...register('email',{required:'This is rquired filed'})} type='email'   sx={{marginBottom:'1rem'}}/>
                        {errors.email && <Typography variant='body2' color='red'>{errors.email.message?.toString()}</Typography>}
                      </Stack>
                    </Grid>
                    <Grid size={12}>
                      <Stack>
                        <InputLabel id="demo-simple-select-label">Password</InputLabel>
                        <TextField {...register('password',{required:'This is rquired filed'})} type='password'   sx={{marginBottom:'1rem'}}/>
                        {errors.password && <Typography variant='body2' color='red'>{errors.password.message?.toString()}</Typography>}
                      </Stack>
                    </Grid>
                    <Grid size={12}>
                      <Stack>
                        <InputLabel id="demo-simple-select-label">Role</InputLabel>
                          <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            // value={age}
                            label="Role"
                            onChange={handleChange}
                          >
                            <MenuItem value={'Admin'}>Admin</MenuItem>
                            <MenuItem value={'Student'}>Student</MenuItem>
                          </Select>
                        {errors.role && <Typography variant='body2' color='red'>{errors.role.message?.toString()}</Typography>}
                      </Stack>
                    </Grid>

                  </Grid>
                </Box>
                
    
                

                <Button variant="contained" fullWidth sx={{marginBottom:'1rem',backgroundColor:'#EF6B4A',marginTop:5}}>Register</Button>
                <Button type='submit' variant="outlined" fullWidth sx={{marginBottom:'1rem',marginTop:5}} >Login</Button>
              </form>
              
        </Stack>
  )
}
