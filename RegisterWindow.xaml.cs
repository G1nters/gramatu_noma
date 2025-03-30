<Window x:Class="RegisterWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Register" Height="350" Width="400">
    <Grid>
        <TextBlock Text="Name:" Margin="10,20,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        <TextBox x:Name="NameTextBox" Width="250" Height="25" Margin="80,20,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        
        <TextBlock Text="Email:" Margin="10,60,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        <TextBox x:Name="EmailTextBox" Width="250" Height="25" Margin="80,60,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        
        <TextBlock Text="Password:" Margin="10,100,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        <PasswordBox x:Name="PasswordBox" Width="250" Height="25" Margin="80,100,0,0" VerticalAlignment="Top" HorizontalAlignment="Left"/>
        
        <Button Content="Register" Width="100" Height="30" Margin="150,140,0,0" VerticalAlignment="Top" HorizontalAlignment="Left" Click="RegisterButton_Click"/>
    </Grid>
</Window>
