%% Define Constants
%System Constants
L = 123.2; % mm
pitch = 2; %mm/tooth
pinion = 20; %teeth/rot
motorCPR = 48; %counts/rev
gearRatio = 20.4; % motor/rotor
Vs = 5;

% Control Constants
Kd = 65535/L;
Kenc = 4*pitch*pinion/(gearRatio*motorCPR);
Ke = 1;
Kv = 0.003135; % counts/V
tau = 0.02375; % s
Kpwm = Vs/65535; %V/int
T = 5e-3; %s

% Transfer Function
s=tf('s');
sys = Kpwm*(Kv/(tau*s+1))*(Ke/s)*Kenc*Kd;
dsys = c2d(sys,T, 'zoh');

% Plot Root Locus of System
figure(1);
rlocus(dsys);
title("Root Locus of Discrete System");
zoom on;
sgrid;

figure(2);
rlocus(sys);
title("Root Locus of Continuous System");
zoom on;
sgrid;

% Find PM and GM
figure(3);
[mag_d, phase_d] = bode(dsys);
[Gm_dsys, Pm_dsys, W_cg_dsys, W_cp_dsys] = margin(dsys);
margin(dsys)
grid on;

figure(4);
[mag, phase] = bode(sys);
[Gm_sys, Pm_sys, W_cg_sys, W_cp_sys] = margin(sys);
margin(sys)
grid on;


