<Window x:Class="LoginWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Login" Height="300" Width="400">
    <Grid>
        <TextBlock Text="Email:" Margin="10,30,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        <TextBox x:Name="EmailTextBox" Width="250" Height="25" Margin="80,30,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        
        <TextBlock Text="Password:" Margin="10,70,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        <PasswordBox x:Name="PasswordBox" Width="250" Height="25" Margin="80,70,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        
        <Button Content="Login" Width="100" Height="30" Margin="150,110,0,0" VerticalAlignment="Top" HorizontalAlignment="Left" Click="LoginButton_Click"/>
        
        <Button Content="Register" Width="100" Height="30" Margin="150,150,0,0" VerticalAlignment="Top" HorizontalAlignment="Left" Click="OpenRegisterWindow_Click"/>
    </Grid>
</Window>
