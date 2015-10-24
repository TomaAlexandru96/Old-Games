#include <iostream>
#include <string.h>
using namespace std;
char a[100][100],aux[100][100],sirc[10];
int col[10]={1,7,15,23,31,39,47,55,63,69},lin[10]={1,4,9,14,19,24,29,34,39,43},t[10][10],aux2[10][10],coox,cooy,xra,yra,xrn,yrn;
//--------------------------------------------------------------------------------------------
void afisare2()
{
    int i,j;
    for(i=1;i<=8;i++)
    {
        for(j=1;j<=8;j++)
            cout<<t[i][j]<<"  ";
        cout<<endl;
    }
}

void flipt()
{
    int i,j,x,y;
    x=8;
    y=8;
    for(i=1;i<=8;i++)
    {
        for(j=1;j<=8;j++)
        {
            aux2[i][j]=0;
        }
    }
    for(i=1;i<=8;i++)
    {
        y=8;
        for(j=1;j<=8;j++)
        {
            aux2[i][j]=t[x][y];
            y--;
        }
        x--;
    }
    for(i=1;i<=8;i++)
    {
        for(j=1;j<=8;j++)
        {
            t[i][j]=aux2[i][j];
        }
    }
}

void select(int x,int y)
{
    char c;
    c=254;
    x--;
    y--;
    y--;
    y--;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y=y-6;
    x++;
    a[x][y]=c;
    y=y+6;
    a[x][y]=c;
    x++;
    y=y-6;
    a[x][y]=c;
    y=y+6;
    a[x][y]=c;
    y=y-6;
    x++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
}

void afisare()
{
    int i,j;
    for (i=0;i<=45;i++)
    {
        for (j=0;j<=71;j++)
            cout<<a[i][j];
        cout<<endl;
    }
}

void neg(int x,int y)
{
    x++;
    y--;
    a[x][y]='N';
    y++;
    a[x][y]='e';
    y++;
    a[x][y]='g';
}

void alb(int x,int y)
{
    x++;
    y--;
    a[x][y]='A';
    y++;
    a[x][y]='l';
    y++;
    a[x][y]='b';
}

void casutaalbao(int x,int y)
{
    char c;
    c='@';
    x--;y--;y--;y--;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y=y-6;x++;a[x][y]=c;y=y+6;a[x][y]=c;x++;y=y-6;a[x][y]=c;y=y+6;a[x][y]=c;y=y-6;x++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;y++;a[x][y]=c;
}

void casutaalban(int xx,int yy)
{
    casutaalbao(xx,yy);
    yy=yy-2;
    char c;
    c='@';
    a[xx][yy]=c;yy++;a[xx][yy]=c;yy++;a[xx][yy]=c;yy++;a[xx][yy]=c;yy++;a[xx][yy]=c;xx++;yy=yy-4;a[xx][yy]=c;yy++;a[xx][yy]=c;yy++;a[xx][yy]=c;yy++;a[xx][yy]=c;yy++;a[xx][yy]=c;
}

void casutaalbaoo(int x,int y)
{
    char c;
    c='@';
    x--;y--;y--;y--;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y=y-6;x++;aux[x][y]=c;y=y+6;aux[x][y]=c;x++;y=y-6;aux[x][y]=c;y=y+6;aux[x][y]=c;y=y-6;x++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;y++;aux[x][y]=c;
}

void casutaalbann(int xx,int yy)
{
    casutaalbaoo(xx,yy);
    yy=yy-2;
    char c;
    c='@';
    aux[xx][yy]=c;yy++;aux[xx][yy]=c;yy++;aux[xx][yy]=c;yy++;aux[xx][yy]=c;yy++;aux[xx][yy]=c;xx++;yy=yy-4;aux[xx][yy]=c;yy++;aux[xx][yy]=c;yy++;aux[xx][yy]=c;yy++;aux[xx][yy]=c;yy++;aux[xx][yy]=c;
}

void resetaux()
{
    int ok,x1,i,j;
    char charm;
    for (i=2;i<=42;i++)
    {
        if(i==2 || i==42)
        {
            x1=i;
            strcpy(aux[i],"    --------------------------------------------------------------- ");
        }
        else
        {
            if(i-5==x1)
            {
                strcpy(aux[i],"   |-------|-------|-------|-------|-------|-------|-------|-------|");
                x1=i;
            }
            else
                strcpy(aux[i],"   |       |       |       |       |       |       |       |       |");
        }
    }
    ok=1;
    for(i=1;i<=8;i++)
    {
        if (ok==1)
            ok=0;
        else
            ok=1;
        for(j=1;j<=8;j++)
        {
            if (ok==1)
                ok=0;
            else
                ok=1;
            if (ok==1)
            {
                if (t[i][j]==0)
                    casutaalbann(lin[i],col[j]);
                else
                    casutaalbaoo(lin[i],col[j]);
            }
        }
    }
    i=lin[0];
    charm='A';
    for (j=1;j<=8;j++)
    {
        aux[i][col[j]]=charm;
        charm++;
    }
    i=lin[9];
    charm='A';
    for (j=1;j<=8;j++)
    {
        aux[i][col[j]]=charm;
        charm++;
    }
    j=col[0];
    charm='1';
    for (i=1;i<=8;i++)
    {
        aux[lin[i]][j]=charm;
        charm++;
    }
    j=col[9];
    charm='1';
    for (i=1;i<=8;i++)
    {
        aux[lin[i]][j]=charm;
        charm++;
    }
}

void deselect(int x,int y)
{
    char c;
    resetaux();
    x--;
    y--;
    y--;
    if (aux[x][y]==' ')
    {
        c=' ';
    }
    else
    {
        c='@';
    }
    y--;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y=y-6;
    x++;
    a[x][y]=c;
    y=y+6;
    a[x][y]=c;
    x++;
    y=y-6;
    a[x][y]=c;
    y=y+6;
    a[x][y]=c;
    y=y-6;
    x++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
    y++;
    a[x][y]=c;
}

void flip()
{
    flipt();
    int i,j,x,y;
    resetaux();
    //--------------------------------------------------------------------------------------------
    for (i=1;i<=45;i++)
    {
        for (j=1;j<=71;j++)
        {
            if ((a[i][j]=='N' && a[i][j+1]=='e') || a[i][j]=='A')
            {
                a[i][j]=' ';
                j++;
                a[i][j]=' ';
                j++;
                a[i][j]=' ';
            }
        }
    }
    //--------------------------------------------------------------------------------------------
    x=8;
    for(i=1;i<=8;i++)
    {
        y=8;
        for(j=1;j<=8;j++)
        {
            aux[lin[i]][col[j]]=a[lin[x]][col[y]];
            y--;
        }
        x--;
    }
    for(i=1;i<=45;i++)
    {
        for(j=1;j<=71;j++)
        {
            a[i][j]=aux[i][j];
        }
    }
    for(i=1;i<=8;i++)
    {
        for(j=1;j<=8;j++)
        {
            if(t[i][j]>0)
            {
                alb(lin[i],col[j]);
            }
            if(t[i][j]<0)
            {
                neg(lin[i],col[j]);
            }
        }
    }
}

void convertire()
{
    coox=sirc[0]-48;
    if (sirc[1]=='A')
        cooy=1;
    if (sirc[1]=='B')
        cooy=2;
    if (sirc[1]=='C')
        cooy=3;
    if (sirc[1]=='D')
        cooy=4;
    if (sirc[1]=='E')
        cooy=5;
    if (sirc[1]=='F')
        cooy=6;
    if (sirc[1]=='G')
        cooy=7;
    if (sirc[1]=='H')
        cooy=8;
}

void aranjare()
{
    char s2[3];
    s2[0]=0;
    s2[1]=0;
    if(sirc[0]>'0' && sirc[0]<'9')
    {
        if(sirc[1]>96 && sirc[1]<'i')
        {
            if (sirc[1]=='a')
                sirc[1]='A';
            if (sirc[1]=='b')
                sirc[1]='B';
            if (sirc[1]=='c')
                sirc[1]='C';
            if (sirc[1]=='d')
                sirc[1]='D';
            if (sirc[1]=='e')
                sirc[1]='E';
            if (sirc[1]=='f')
                sirc[1]='F';
            if (sirc[1]=='g')
                sirc[1]='G';
            if (sirc[1]=='h')
                sirc[1]='H';
        }
    }
    if(sirc[0]>96 && sirc[0]<'i')
    {
        if (sirc[0]=='a')
            sirc[0]='A';
        if (sirc[0]=='b')
            sirc[0]='B';
        if (sirc[0]=='c')
            sirc[0]='C';
        if (sirc[0]=='d')
            sirc[0]='D';
        if (sirc[0]=='e')
            sirc[0]='E';
        if (sirc[0]=='f')
            sirc[0]='F';
        if (sirc[0]=='g')
            sirc[0]='G';
        if (sirc[0]=='h')
            sirc[0]='H';
        s2[1]=sirc[0];
        s2[0]=sirc[1];
        sirc[0]=s2[0];
        sirc[1]=s2[1];
    }
    if (sirc[0]>=64 && sirc[0]<'I')
    {
        s2[1]=sirc[0];
        s2[0]=sirc[1];
        sirc[0]=s2[0];
        sirc[1]=s2[1];
    }
    convertire();
}

int verificarecoo()
{
    cin>>sirc;
    if (strlen(sirc)==2)
    {
        if ((sirc[0]>'0' && sirc[0]<'9') || (sirc[0]>96 && sirc[0]<'i') || (sirc[0]>64 && sirc[0]<'I'))
        {
            if ((sirc[1]>'0' && sirc[1]<'9') || (sirc[1]>96 && sirc[1]<'i') || (sirc[1]>64 && sirc[1]<'I'))
            {
                if ((sirc[0]>'0' && sirc[0]<'9') && ((sirc[1]>96 && sirc[1]<'i') || (sirc[1]>=64 && sirc[1]<'I')))
                    return 1;
                if ((sirc[1]>'0' && sirc[1]<'9') && ((sirc[0]>96 && sirc[0]<'i') || (sirc[0]>=64 && sirc[0]<'I')))
                    return 1;
                return 0;
            }
            return 0;
        }
        return 0;
    }
    return 0;
}

void stergere(int x,int y)
{
    int t=0,i,j;
    y=y-2;
    x--;
    resetaux();
    if (aux[x][y]!=' ')
        t=1;
    y--;
    if (t==1)
    {
        for (i=x;i<=x+3;i++)
        {
            for (j=y;j<=y+6;j++)
            {
                a[i][j]='@';
            }
        }
    }
    else
    {
        for (i=x;i<=x+3;i++)
        {
            for (j=y;j<=y+6;j++)
            {
                a[i][j]=' ';
            }
        }
    }
}

void scriere(int x,int y)
{
    int xx,yy;
    xx=lin[x];
    yy=col[y];
    yy--;
    yy--;
    if (t[x][y]==1)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='P';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        alb(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==2)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='T';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        alb(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==3)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='C';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        alb(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==4)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='N';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        alb(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==5)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='Q';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        alb(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==6)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='R';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        alb(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==-1)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='P';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        neg(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==-2)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='T';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        neg(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==-3)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='C';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        neg(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==-4)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='N';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        neg(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==-5)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='Q';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        neg(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
    if (t[x][y]==-6)
    {
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]='R';
        yy++;
        a[xx][yy]=' ';
        yy++;
        a[xx][yy]=' ';
        yy=yy-2;
        neg(xx,yy);
        xx++;
        yy=yy-2;
        a[xx][yy]=' ';
        yy=yy+4;
        a[xx][yy]=' ';
    }
}
//--------------------------------------------------------------------------------------------
int opuse(int xx1,int yy1,int xx2,int yy2)
{
    if (t[xx1][yy1]>0 && t[xx2][yy2]<0)
        return 1;
    if (t[xx1][yy1]<0 && t[xx2][yy2]>0)
        return 1;
    return 0;
}

int mutarepioninvers(int x1,int y1,int x2,int y2)
{
    int x;
    x=x1;
    if (t[x2][y2]==0 && y1==y2)
    {
        if (x1==7)
        {
            x1++;
            if (x1==x2)
                return 1;
            x1++;
            if (x1==x2)
                return 1;
        }
        x1=x;
        x1++;
        if(x1==x2)
            return 1;
    }
    if (t[x2][y2]!=0)
    {
        if (opuse(x1,y1,x2,y2)==1)
        {
            x1++;
            y1++;
            if (x1==x2 && y1==y2)
            {
                return 1;
            }
            y1--;
            y1--;
            if (x1==x2 && y1==y2)
            {
                return 1;
            }
        }
    }
    return 0;
}

int mutarepion(int x1,int y1,int x2,int y2)
{
    int x;
    x=x1;
    if (t[x2][y2]==0 && y1==y2)
    {
        if (x1==7)
        {
            x1--;
            if (x1==x2)
                return 1;
            x1--;
            if (x1==x2)
                return 1;
        }
        x1=x;
        x1--;
        if(x1==x2)
            return 1;
    }
    if (t[x2][y2]!=0)
    {
        if (opuse(x1,y1,x2,y2)==1)
        {
            x1--;
            y1--;
            if (x1==x2 && y1==y2)
            {
                return 1;
            }
            y1++;
            y1++;
            if (x1==x2 && y1==y2)
            {
                return 1;
            }
        }
    }
    return 0;
}

int mutaretura(int x1,int y1,int x2,int y2)
{
    int i,ok=1;
    if (t[x2][y2]==0)
    {
        if (y1==y2)
        {
            if (x1<x2)
                for (i=x1+1;i<=x2;i++)
                {
                    if (t[i][y1]!=0)
                        ok=0;
                }
            else
                for (i=x1-1;i>=x2;i--)
                {
                    if (t[i][y1]!=0)
                        ok=0;
                }
            if (ok==1)
                return 1;
        }
        if (x1==x2)
        {
            if (y1<y2)
                for (i=y1+1;i<=y2;i++)
                {
                    if (t[x1][i]!=0)
                        ok=0;
                }
            else
                for (i=y1-1;i>=y2;i--)
                {
                    if (t[x1][i]!=0)
                        ok=0;
                }
            if (ok==1)
                return 1;
        }
    }
    else
    {
        if (opuse(x1,y1,x2,y2)==1)
        {
            if (y1==y2)
            {
                if (x1<x2)
                    for (i=x1+1;i<x2;i++)
                    {
                        if (t[i][y1]!=0)
                            ok=0;
                    }
                else
                    for (i=x1-1;i>x2;i--)
                    {
                        if (t[i][y1]!=0)
                            ok=0;
                    }
                if (ok==1)
                    return 1;
            }
            if (x1==x2)
            {
                if (y1<y2)
                    for (i=y1+1;i<y2;i++)
                    {
                        if (t[x1][i]!=0)
                            ok=0;
                    }
                else
                    for (i=y1-1;i>y2;i--)
                    {
                        if (t[x1][i]!=0)
                            ok=0;
                    }
                if (ok==1)
                    return 1;
            }
        }
    }
    return 0;
}

int mutarecal(int x1,int y1,int x2,int y2)
{
    if (t[x2][y2]==0)
    {
        if (x1-2==x2 && y1+1==y2)
            return 1;
        if (x1-2==x2 && y1-1==y2)
            return 1;
        if (x1+1==x2 && y1-2==y2)
            return 1;
        if (x1-1==x2 && y1-2==y2)
            return 1;
        if (x1+2==x2 && y1+1==y2)
            return 1;
        if (x1+2==x2 && y1-1==y2)
            return 1;
        if (x1-1==x2 && y1+2==y2)
            return 1;
        if (x1+1==x2 && y1+2==y2)
            return 1;
    }
    else
    {
        if (opuse(x1,y1,x2,y2)==1)
        {
            if (x1-2==x2 && y1+1==y2)
                return 1;
            if (x1-2==x2 && y1-1==y2)
                return 1;
            if (x1+1==x2 && y1-2==y2)
                return 1;
            if (x1-1==x2 && y1-2==y2)
                return 1;
            if (x1+2==x2 && y1+1==y2)
                return 1;
            if (x1+2==x2 && y1-1==y2)
                return 1;
            if (x1-1==x2 && y1+2==y2)
                return 1;
            if (x1+1==x2 && y1+2==y2)
                return 1;
        }
    }
    return 0;
}

int mutarenebun(int x1,int y1,int x2,int y2)
{
    int i,j,ok;
    if (t[x2][y2]==0)
    {
        ok=1;
        i=x1;
        j=y1;
        if (x1>x2 && y1<y2)
        while (i>x2 && j<y2)
        {
            i--;
            j++;
            if (t[i][j]!=0)
            {
                ok=0;
            }
            if (i==x2 && j==y2)
            {
                if (ok==1)
                {
                    return 1;
                }
            }
        }
        i=x1;
        j=y1;
        if (x1<x2 && y1<y2)
        while (i<x2 && j<y2)
        {
            i++;
            j++;
            if (t[i][j]!=0)
            {
                ok=0;
            }
            if (i==x2 && j==y2)
            {
                if (ok==1)
                {
                    return 1;
                }
            }
        }
        i=x1;
        j=y1;
        if (x1<x2 && y1>y2)
        while (i<x2 && j>y2)
        {
            i++;
            j--;
            if (t[i][j]!=0)
            {
                ok=0;
            }
            if (i==x2 && j==y2)
            {
                if (ok==1)
                {
                    return 1;
                }
            }
        }
        i=x1;
        j=y1;
        if (x1>x2 && y1>y2)
        while (i>x2 && j>y2)
        {
            i--;
            j--;
            if (t[i][j]!=0)
            {
                ok=0;
            }
            if (i==x2 && j==y2)
            {
                if (ok==1)
                {
                    return 1;
                }
            }
        }
    }
    else
    {
        if (opuse(x1,y1,x2,y2)==1)
        {
            ok=1;
            i=x1;
            j=y1;
            if (x1>x2 && y1<y2)
            while (i>=x2 && j<=y2)
            {
                i--;
                j++;
                if (t[i][j]!=0 && i!=x2 )
                {
                    ok=0;
                }
                if (i==x2 && j==y2)
                {
                    if (ok==1)
                    {
                        return 1;
                    }
                }
            }
            i=x1;
            j=y1;
            if (x1<x2 && y1<y2)
            while (i<=x2 && j<=y2)
            {
                i++;
                j++;
                if (t[i][j]!=0 && i!=x2 )
                {
                    ok=0;
                }
                if (i==x2 && j==y2)
                {
                    if (ok==1)
                    {
                        return 1;
                    }
                }
            }
            i=x1;
            j=y1;
            if (x1<x2 && y1>y2)
            while (i<=x2 && j>=y2)
            {
                i++;
                j--;
                if (t[i][j]!=0 && i!=x2 )
                {
                    ok=0;
                }
                if (i==x2 && j==y2)
                {
                    if (ok==1)
                    {
                        return 1;
                    }
                }
            }
            i=x1;
            j=y1;
            if (x1>x2 && y1>y2)
            while (i>=x2 && j>=y2)
            {
                i--;
                j--;
                if (t[i][j]!=0 && i!=x2 )
                {
                    ok=0;
                }
                if (i==x2 && j==y2)
                {
                    if (ok==1)
                    {
                        return 1;
                    }
                }
            }
        }
    }
    return 0;
}

int mutareregina(int x1,int y1,int x2,int y2)
{
    int i,j,ok=1;
    if (t[x2][y2]==0)
    {
        if (y1==y2)
        {
            if (x1<x2)
                for (i=x1+1;i<=x2;i++)
                {
                    if (t[i][y1]!=0)
                        ok=0;
                }
            else
                for (i=x1-1;i>=x2;i--)
                {
                    if (t[i][y1]!=0)
                        ok=0;
                }
            if (ok==1)
                return 1;
        }
        if (x1==x2)
        {
            if (y1<y2)
                for (i=y1+1;i<=y2;i++)
                {
                    if (t[x1][i]!=0)
                        ok=0;
                }
            else
                for (i=y1-1;i>=y2;i--)
                {
                    if (t[x1][i]!=0)
                        ok=0;
                }
            if (ok==1)
                return 1;
        }
//--------------------------------------------------------------------------------------------
        ok=1;
        i=x1;
        j=y1;
        if (x1>x2 && y1<y2)
        while (i>x2 && j<y2)
        {
            i--;
            j++;
            if (t[i][j]!=0)
            {
                ok=0;
            }
            if (i==x2 && j==y2)
            {
                if (ok==1)
                {
                    return 1;
                }
            }
        }
        i=x1;
        j=y1;
        if (x1<x2 && y1<y2)
        while (i<x2 && j<y2)
        {
            i++;
            j++;
            if (t[i][j]!=0)
            {
                ok=0;
            }
            if (i==x2 && j==y2)
            {
                if (ok==1)
                {
                    return 1;
                }
            }
        }
        i=x1;
        j=y1;
        if (x1<x2 && y1>y2)
        while (i<x2 && j>y2)
        {
            i++;
            j--;
            if (t[i][j]!=0)
            {
                ok=0;
            }
            if (i==x2 && j==y2)
            {
                if (ok==1)
                {
                    return 1;
                }
            }
        }
        i=x1;
        j=y1;
        if (x1>x2 && y1>y2)
        while (i>x2 && j>y2)
        {
            i--;
            j--;
            if (t[i][j]!=0)
            {
                ok=0;
            }
            if (i==x2 && j==y2)
            {
                if (ok==1)
                {
                    return 1;
                }
            }
        }
    }
    else
    {
        if (opuse(x1,y1,x2,y2)==1)
        {
            if (y1==y2)
            {
                if (x1<x2)
                    for (i=x1+1;i<x2;i++)
                    {
                        if (t[i][y1]!=0)
                            ok=0;
                    }
                else
                    for (i=x1-1;i>x2;i--)
                    {
                        if (t[i][y1]!=0)
                            ok=0;
                    }
                if (ok==1)
                    return 1;
            }
            if (x1==x2)
            {
                if (y1<y2)
                    for (i=y1+1;i<y2;i++)
                    {
                        if (t[x1][i]!=0)
                            ok=0;
                    }
                else
                    for (i=y1-1;i>y2;i--)
                    {
                        if (t[x1][i]!=0)
                            ok=0;
                    }
                if (ok==1)
                    return 1;
            }
    //--------------------------------------------------------------------------------------------
            ok=1;
            i=x1;
            j=y1;
            if (x1>x2 && y1<y2)
            while (i>=x2 && j<=y2)
            {
                i--;
                j++;
                if (t[i][j]!=0 && i!=x2 )
                {
                    ok=0;
                }
                if (i==x2 && j==y2)
                {
                    if (ok==1)
                    {
                        return 1;
                    }
                }
            }
            i=x1;
            j=y1;
            if (x1<x2 && y1<y2)
            while (i<=x2 && j<=y2)
            {
                i++;
                j++;
                if (t[i][j]!=0 && i!=x2 )
                {
                    ok=0;
                }
                if (i==x2 && j==y2)
                {
                    if (ok==1)
                    {
                        return 1;
                    }
                }
            }
            i=x1;
            j=y1;
            if (x1<x2 && y1>y2)
            while (i<=x2 && j>=y2)
            {
                i++;
                j--;
                if (t[i][j]!=0 && i!=x2 )
                {
                    ok=0;
                }
                if (i==x2 && j==y2)
                {
                    if (ok==1)
                    {
                        return 1;
                    }
                }
            }
            i=x1;
            j=y1;
            if (x1>x2 && y1>y2)
            while (i>=x2 && j>=y2)
            {
                i--;
                j--;
                if (t[i][j]!=0 && i!=x2 )
                {
                    ok=0;
                }
                if (i==x2 && j==y2)
                {
                    if (ok==1)
                    {
                        return 1;
                    }
                }
            }
        }
    }
    return 0;
}

int mutarerege(int x1,int y1,int x2,int y2)
{
    int i,j;
    if (t[x2][y2]==0)
    {
        i=x1;
        j=y1;
        i++;
        j++;
        if (i==x2 && j==y2)
            return 1;
        i=x1;
        j=y1;
        i--;
        j++;
        if (i==x2 && j==y2)
            return 1;
        i=x1;
        j=y1;
        i++;
        j--;
        if (i==x2 && j==y2)
            return 1;
        i=x1;
        j=y1;
        i--;
        j--;
        if (i==x2 && j==y2)
            return 1;
        i=x1;
        j=y1;
        i++;
        if (i==x2 && j==y2)
            return 1;
        i=x1;
        j=y1;
        i--;
        if (i==x2 && j==y2)
            return 1;
        i=x1;
        j=y1;
        j++;
        if (i==x2 && j==y2)
            return 1;
        i=x1;
        j=y1;
        j--;
        if (i==x2 && j==y2)
            return 1;
    }
    else
    {
        if (opuse(x1,y1,x2,y2)==1)
        {
            i=x1;
            j=y1;
            i++;
            j++;
            if (i==x2 && j==y2)
                return 1;
            i=x1;
            j=y1;
            i--;
            j++;
            if (i==x2 && j==y2)
                return 1;
            i=x1;
            j=y1;
            i++;
            j--;
            if (i==x2 && j==y2)
                return 1;
            i=x1;
            j=y1;
            i--;
            j--;
            if (i==x2 && j==y2)
                return 1;
            i=x1;
            j=y1;
            i++;
            if (i==x2 && j==y2)
                return 1;
            i=x1;
            j=y1;
            i--;
            if (i==x2 && j==y2)
                return 1;
            i=x1;
            j=y1;
            j++;
            if (i==x2 && j==y2)
                return 1;
            i=x1;
            j=y1;
            j--;
            if (i==x2 && j==y2)
                return 1;
        }
    }
    return 0;
}

void schimbarepion(int x1,int y1)
{
    int ok=0;
    char ch;
    while (ok==0)
    {
        cout<<"    Replace with (T,C,N,Q):";
        cin>>ch;
        if (ch=='t')
            ch='T';
        if (ch=='c')
            ch='C';
        if (ch=='n')
            ch='N';
        if (ch=='q')
            ch='Q';
        if (ch=='T')
        {
            if (t[x1][y1]>0)
            {
                t[x1][y1]=2;
                scriere(x1,y1);
                alb(lin[x1],col[y1]);
                ok=1;
            }
            if (t[x1][y1]<0)
            {
                t[x1][y1]=-2;
                scriere(x1,y1);
                neg(lin[x1],col[y1]);
                ok=1;
            }
        }
        if (ch=='C')
        {
            if (t[x1][y1]>0)
            {
                t[x1][y1]=3;
                scriere(x1,y1);
                alb(lin[x1],col[y1]);
                ok=1;
            }
            if (t[x1][y1]<0)
            {
                t[x1][y1]=-3;
                scriere(x1,y1);
                neg(lin[x1],col[y1]);
                ok=1;
            }
        }
        if (ch=='N')
        {
            if (t[x1][y1]>0)
            {
                t[x1][y1]=4;
                scriere(x1,y1);
                alb(lin[x1],col[y1]);
                ok=1;
            }
            if (t[x1][y1]<0)
            {
                t[x1][y1]=-4;
                scriere(x1,y1);
                neg(lin[x1],col[y1]);
                ok=1;
            }
        }
        if (ch=='Q')
        {
            if (t[x1][y1]>0)
            {
                t[x1][y1]=5;
                scriere(x1,y1);
                alb(lin[x1],col[y1]);
                ok=1;
            }
            if (t[x1][y1]<0)
            {
                t[x1][y1]=-5;
                scriere(x1,y1);
                neg(lin[x1],col[y1]);
                ok=1;
            }
        }
    }
}

int sah(int xx1,int yy1)
{
    int i,j;
    if (t[xx1][yy1]>0)
    {
        for (i=1;i<=8;i++)
        {
            for (j=1;j<=8;j++)
            {
                if (t[i][j]<0)
                {
                    if (t[i][j]==-1)
                    {
                        if (mutarepioninvers(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==-2)
                    {
                        if (mutaretura(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==-3)
                    {
                        if (mutarecal(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==-4)
                    {
                        if (mutarenebun(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==-5)
                    {
                        if (mutareregina(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==-6)
                    {
                        if (mutarerege(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                }
            }
        }
    }
    if (t[xx1][yy1]<0)
    {
         for (i=1;i<=8;i++)
        {
            for (j=1;j<=8;j++)
            {
                if (t[i][j]>0)
                {
                    if (t[i][j]==1)
                    {
                        if (mutarepioninvers(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==2)
                    {
                        if (mutaretura(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==3)
                    {
                        if (mutarecal(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==4)
                    {
                        if (mutarenebun(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==5)
                    {
                        if (mutareregina(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                    if (t[i][j]==6)
                    {
                        if (mutarerege(i,j,xx1,yy1)==1)
                        {
                            return 1;
                        }
                    }
                }
            }
        }
    }
    return 0;
}

int verifrocada(int x1,int y1,int x2,int y2)
{
    if (t[x1][y1]>0)
        if (x1==x2)
            if (t[x1][y1]==6)
            {
                if (t[x2][y2]==2)
                {
                    if (y2-y1==3)
                    {
                        if (t[x1][y1+1]==0 && t[x1][y1+2]==0)
                        {
                            return 1;
                        }
                    }
                    if (y1-y2==4)
                    {
                        if (t[x1][y1-1]==0 && t[x1][y1-2]==0 && t[x1][y1-3]==0)
                        {
                            return 1;
                        }
                    }
                }
            }
    if (t[x1][y1]<0)
    {
        if (x1==x2)
            if (t[x1][y1]==-6)
            {
                if (t[x2][y2]==-2)
                {
                    if (y1-y2==3)
                    {
                        if (t[x1][y1-1]==0 && t[x1][y1-2]==0)
                        {
                            return 1;
                        }
                    }
                    if (y2-y1==4)
                    {
                        if (t[x1][y1+1]==0 && t[x1][y1+2]==0 && t[x1][y1+3]==0)
                        {
                            return 1;
                        }
                    }
                }
            }
    }
    return 0;
}

void rocada(int x1,int y1,int x2,int y2)
{
    if (t[x1][y1]>0)
        if (x1==x2)
            if (t[x1][y1]==6)
            {
                if (t[x2][y2]==2)
                {
                    if (y2-y1==3)
                    {
                        if (t[x1][y1+1]==0 && t[x1][y1+2]==0)
                        {
                            t[x1][y1+1]=2;
                            t[x1][y1+2]=6;
                            t[x1][y1]=0;
                            t[x2][y2]=0;
                            a[lin[x1]][col[y1+1]]='T';
                            scriere(x1,y1+1);
                            a[lin[x1]][col[y1+2]]='R';
                            scriere(x1,y1+2);
                            stergere(lin[x1],col[y1]);
                            stergere(lin[x2],col[y2]);
                        }
                    }
                    if (y1-y2==4)
                    {
                        if (t[x1][y1-1]==0 && t[x1][y1-2]==0 && t[x1][y1-3]==0)
                        {
                            t[x1][y1-1]=2;
                            t[x1][y1-2]=6;
                            t[x1][y1]=0;
                            t[x2][y2]=0;
                            a[lin[x1]][col[y1-1]]='T';
                            scriere(x1,y1-1);
                            a[lin[x1]][col[y1-2]]='R';
                            scriere(x1,y1-2);
                            stergere(lin[x1],col[y1]);
                            stergere(lin[x2],col[y2]);
                        }
                    }
                }
            }
    if (t[x1][y1]<0)
    {
        if (x1==x2)
            if (t[x1][y1]==-6)
            {
                if (t[x2][y2]==-2)
                {
                    if (y1-y2==3)
                    {
                        if (t[x1][y1-1]==0 && t[x1][y1-2]==0)
                        {
                            t[x1][y1-1]=-2;
                            t[x1][y1-2]=-6;
                            t[x1][y1]=0;
                            t[x2][y2]=0;
                            a[lin[x1]][col[y1-1]]='T';
                            scriere(x1,y1-1);
                            a[lin[x1]][col[y1-2]]='R';
                            scriere(x1,y1-2);
                            stergere(lin[x1],col[y1]);
                            stergere(lin[x2],col[y2]);
                        }
                    }
                    if (y2-y1==4)
                    {
                        if (t[x1][y1+1]==0 && t[x1][y1+2]==0 && t[x1][y1+3]==0)
                        {
                            t[x1][y1+1]=-2;
                            t[x1][y1+2]=-6;
                            t[x1][y1]=0;
                            t[x2][y2]=0;
                            a[lin[x1]][col[y1+1]]='T';
                            scriere(x1,y1+1);
                            a[lin[x1]][col[y1+2]]='R';
                            scriere(x1,y1+2);
                            stergere(lin[x1],col[y1]);
                            stergere(lin[x2],col[y2]);
                        }
                    }
                }
            }
    }
}

int mutare(int coox1,int cooy1,int coox2,int cooy2)
{
    if (t[coox1][cooy1]==1)
    {
        if (mutarepion(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==2)
    {
        if (mutaretura(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==3)
    {
        if (mutarecal(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==4)
    {
        if (mutarenebun(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==5)
    {
        if (mutareregina(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==6)
    {
        if (mutarerege(coox1,cooy1,coox2,cooy2)==1)
        {
            t[coox2][cooy2]=6;
            if (sah(coox2,cooy2)==0)
                return 1;
            t[coox2][cooy2]=0;
        }
        return 0;
    }
    if (t[coox1][cooy1]==-1)
    {
        if (mutarepion(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==-2)
    {
        if (mutaretura(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==-3)
    {
        if (mutarecal(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==-4)
    {
        if (mutarenebun(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==-5)
    {
        if (mutareregina(coox1,cooy1,coox2,cooy2)==1)
            return 1;
        else
            return 0;
    }
    if (t[coox1][cooy1]==-6)
    {
        if (mutarerege(coox1,cooy1,coox2,cooy2)==1)
        {
            t[coox2][cooy2]=-6;
            if (sah(coox2,cooy2)==0)
                return 1;
            t[coox2][cooy2]=0;
        }
        return 0;
    }
    return 0;
}

int sahmat(int x,int y)
{
    int i,j,ok=1,i2,j2,xx,yy,var,var2;
    if (t[x][y]>0)
    {
        for (i=1;i<=8;i++)
        {
            for (j=1;j<=8;j++)
            {
                for (i2=1;i2<=8;i2++)
                {
                    for (j2=1;j2<=8;j2++)
                    {
                        if (t[i2][j2]>0)
                        {
                            if (t[i2][j2]==1)
                            {
                                if (mutarepion(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=1;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=1;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==2)
                            {
                                if (mutaretura(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=2;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=2;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==3)
                            {
                                if (mutarecal(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=3;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=3;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==4)
                            {
                                if (mutarenebun(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=4;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=4;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==5)
                            {
                                if (mutareregina(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=5;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=5;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==6)
                            {
                                if (mutarerege(i2,j2,i,j)==1)
                                {
                                    xx=i;
                                    yy=j;
                                    var=t[xx][yy];
                                    t[i2][j2]=0;
                                    t[xx][yy]=6;
                                    if (sah(xx,yy)==0)
                                    {
                                        ok=0;
                                    }
                                    t[xx][yy]=var;
                                    t[i2][j2]=6;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    if (t[x][y]<0)
    {
        for (i=1;i<=8;i++)
        {
            for (j=1;j<=8;j++)
            {
                for (i2=1;i2<=8;i2++)
                {
                    for (j2=1;j2<=8;j2++)
                    {
                        if (t[i2][j2]<0)
                        {
                            if (t[i2][j2]==-1)
                            {
                                if (mutarepion(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-1;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=-1;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-2)
                            {
                                if (mutaretura(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-2;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=-2;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-3)
                            {
                                if (mutarecal(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-3;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=-3;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-4)
                            {
                                if (mutarenebun(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-4;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=-4;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-5)
                            {
                                if (mutareregina(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-5;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=0;
                                    }
                                    t[i2][j2]=-5;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-6)
                            {
                                if (mutarerege(i2,j2,i,j)==1)
                                {
                                    xx=i;
                                    yy=j;
                                    var=t[xx][yy];
                                    t[i2][j2]=0;
                                    t[xx][yy]=-6;
                                    if (sah(xx,yy)==0)
                                    {
                                        ok=0;
                                    }
                                    t[xx][yy]=var;
                                    t[i2][j2]=-6;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    if (ok==1)
        return 1;
    else
        return 0;
}

int pat(int x,int y)
{
    int i,j,i2,j2,ok=0,xx,yy,var;
    if (t[x][y]>0)
    {
        for (i=1;i<=8;i++)
        {
            for (j=1;j<=8;j++)
            {
                for (i2=1;i2<=8;i2++)
                {
                    for (j2=1;j2<=8;j2++)
                    {
                        if (t[i2][j2]>0)
                        {
                            if (t[i2][j2]==1)
                            {
                                if (mutarepion(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=1;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=1;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==2)
                            {
                                if (mutaretura(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=2;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=2;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==3)
                            {
                                if (mutarecal(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=3;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=3;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==4)
                            {
                                if (mutarenebun(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=4;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=4;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==5)
                            {
                                if (mutareregina(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=5;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=5;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==6)
                            {
                                if (mutarerege(i2,j2,i,j)==1)
                                {
                                    xx=i;
                                    yy=j;
                                    var=t[xx][yy];
                                    t[i2][j2]=0;
                                    t[xx][yy]=6;
                                    if (sah(xx,yy)==0)
                                    {
                                        ok=1;
                                    }
                                    t[xx][yy]=var;
                                    t[i2][j2]=6;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    if (t[x][y]<0)
    {
        for (i=1;i<=8;i++)
        {
            for (j=1;j<=8;j++)
            {
                for (i2=1;i2<=8;i2++)
                {
                    for (j2=1;j2<=8;j2++)
                    {
                        if (t[i2][j2]<0)
                        {
                            if (t[i2][j2]==-1)
                            {
                                if (mutarepion(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-1;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=-1;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-2)
                            {
                                if (mutaretura(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-2;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=-2;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-3)
                            {
                                if (mutarecal(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-3;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=-3;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-4)
                            {
                                if (mutarenebun(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-4;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=-4;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-5)
                            {
                                if (mutareregina(i2,j2,i,j)==1)
                                {
                                    var=t[i][j];
                                    t[i][j]=-5;
                                    t[i2][j2]=0;
                                    if (sah(x,y)==0)
                                    {
                                        ok=1;
                                    }
                                    t[i2][j2]=-5;
                                    t[i][j]=var;
                                }
                            }
                            if (t[i2][j2]==-6)
                            {
                                if (mutarerege(i2,j2,i,j)==1)
                                {
                                    xx=i;
                                    yy=j;
                                    var=t[xx][yy];
                                    t[i2][j2]=0;
                                    t[xx][yy]=-6;
                                    if (sah(xx,yy)==0)
                                    {
                                        ok=1;
                                    }
                                    t[xx][yy]=var;
                                    t[i2][j2]=-6;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    if (ok==1)
        return 1;
    else
        return 0;
}

int main()
{
    int i,j,ok,x1,x2,y1,y2,albe[4]={0,1,1,1},negre[4]={0,1,1,1};
    char p1[256],p2[256],charm;
    xra=8;
    yra=5;
    xrn=8;
    yrn=4;
    cout<<"    Player 1:";
    cin>>p1;
    cout<<"    Player 2:";
    cin>>p2;
    cout<<endl;
    cout<<"    Rules:";
    cout<<endl;
    cout<<endl;
    cout<<"    To move a piece type the coordinates of that piece to select it and after that the coordinates of the destination.";
    cout<<endl;
    cout<<"    Eg. : > 7A";
    cout<<endl;
    cout<<"          > 8A";
    cout<<endl;
    cout<<"    This game does not accept en passant rule.";
    cout<<endl;
    cout<<"    To deselect a piece just select it again.";
    cout<<endl;
    cout<<endl;
    cout<<"    Specifications:";
    cout<<endl;
    cout<<endl;
    cout<<"    T = rook";
    cout<<endl;
    cout<<"    P = pawn";
    cout<<endl;
    cout<<"    N = bishop";
    cout<<endl;
    cout<<"    C = horse";
    cout<<endl;
    cout<<"    Q = queen";
    cout<<endl;
    cout<<"    R = king";
    cout<<endl<<endl;
    cout<<"    The game begins:";
    cout<<endl<<endl;
//--------------------------------------------------------------------------------------------
    //Test
    i=2;
    for (j=1;j<=8;j++)
    {
        t[i][j]=-1;
    }
    i=7;
    for (j=1;j<=8;j++)
    {
        t[i][j]=1;
    }
    x1=1;
    x2=8;
    y1=1;
    y2=8;
    t[x1][y1]=-2;
    t[x1][y2]=-2;
    t[x2][y1]=2;
    t[x2][y2]=2;

    y1=2;
    y2=7;
    t[x1][y1]=-3;
    t[x1][y2]=-3;
    t[x2][y1]=3;
    t[x2][y2]=3;

    y1=3;
    y2=6;
    t[x1][y1]=-4;
    t[x1][y2]=-4;
    t[x2][y1]=4;
    t[x2][y2]=4;

    y1=4;
    y2=5;
    t[x1][y1]=-5;
    t[x1][y2]=-6;
    t[x2][y1]=5;
    t[x2][y2]=6;
    //Test
//--------------------------------------------------------------------------------------------TESTPAT
    /*x1=7;
    y1=4;
    t[x1][y1]=2;
    y1=6;
    t[x1][y1]=2;
    x1=1;
    y1=5;
    t[x1][y1]=-6;
    x1=8;
    t[x1][y1]=6;
    x1=2;
    y1=1;
    t[x1][y1]=2;
    x1=3;
    y1=7;
    t[x1][y1]=-1;
    x1=5;
    t[x1][y1]=2;*/
    //--------------------------------------------------------------------------------------------negru
    /*x1=2;
    y1=4;
    t[x1][y1]=-2;
    y1=6;
    t[x1][y1]=-2;
    x1=1;
    y1=5;
    t[x1][y1]=-6;
    x1=8;
    t[x1][y1]=6;
    x1=7;
    y1=1;
    t[x1][y1]=-2;
    x1=5;
    y1=7;
    t[x1][y1]=1;
    x1=2;
    t[x1][y1]=-2;*/
//--------------------------------------------------------------------------------------------TESTPAT
    for (i=2;i<=42;i++)
    {
        if(i==2 || i==42)
        {
            x1=i;
            strcpy(a[i],"    --------------------------------------------------------------- ");
        }
        else
        {
            if(i-5==x1)
            {
                strcpy(a[i],"   |-------|-------|-------|-------|-------|-------|-------|-------|");
                x1=i;
            }
            else
                strcpy(a[i],"   |       |       |       |       |       |       |       |       |");
        }
    }
//--------------------------------------------------------------------------------------------
    ok=1;
    for(i=1;i<=8;i++)
    {
        if (ok==1)
            ok=0;
        else
            ok=1;
        for(j=1;j<=8;j++)
        {
            if (ok==1)
                ok=0;
            else
                ok=1;
            if (ok==1)
            {
                if (t[i][j]==0)
                    casutaalban(lin[i],col[j]);
                else
                    casutaalbao(lin[i],col[j]);
            }
        }
    }
//--------------------------------------------------------------------------------------------
    i=lin[0];
    charm='A';
    for (j=1;j<=8;j++)
    {
        a[i][col[j]]=charm;
        charm++;
    }
    i=lin[9];
    charm='A';
    for (j=1;j<=8;j++)
    {
        a[i][col[j]]=charm;
        charm++;
    }
    j=col[0];
    charm='1';
    for (i=1;i<=8;i++)
    {
        a[lin[i]][j]=charm;
        charm++;
    }
    j=col[9];
    charm='1';
    for (i=1;i<=8;i++)
    {
        a[lin[i]][j]=charm;
        charm++;
    }
//--------------------------------------------------------------------------------------------
//Test
    i=lin[2];
    for (j=1;j<=8;j++)
    {
       a[i][col[j]]='P';
       neg(i,col[j]);
    }
    i=lin[7];
    for (j=1;j<=8;j++)
    {
       a[i][col[j]]='P';
       alb(i,col[j]);
    }

    x1=lin[1];
    x2=lin[8];
    y1=col[1];
    y2=col[8];
    a[x1][y1]='T';
    a[x1][y2]='T';
    a[x2][y1]='T';
    a[x2][y2]='T';

    y1=col[2];
    y2=col[7];
    a[x1][y1]='C';
    a[x1][y2]='C';
    a[x2][y1]='C';
    a[x2][y2]='C';

    y1=col[3];
    y2=col[6];
    a[x1][y1]='N';
    a[x1][y2]='N';
    a[x2][y1]='N';
    a[x2][y2]='N';

    y1=col[4];
    y2=col[5];
    a[x1][y1]='Q';
    a[x1][y2]='R';
    a[x2][y1]='Q';
    a[x2][y2]='R';
//--------------------------------------------------------------------------------------------
    i=lin[1];
    for(j=1;j<=8;j++)
    {
        neg(i,col[j]);
    }
    i=lin[8];
    for(j=1;j<=8;j++)
    {
        alb(i,col[j]);
    }
    //Test
//--------------------------------------------------------------------------------------------
    int sw=2,okk,xx,yy,okkk,dis,ok10,sahh=0,v,v2,sm=0;
    ok=1;
    while(ok==1)
    {
        afisare();
        if(sw==1)
            sw=2;
        else
            sw=1;
        if (sw==1)
            cout<<"    "<<p1<<" it is your turn:"<<endl;
        else
            cout<<"    "<<p2<<" it is your turn:"<<endl;
        okk=0;
        while(okk==0)
        {
            if (verificarecoo()==1)
                if (sw==1)
                {
                    aranjare();
                    if(t[coox][cooy]>0)
                        okk=1;
                    else
                        cout<<"    Wrong coordinates:";
                }
                else
                {
                    aranjare();
                    if(t[coox][cooy]<0)
                        okk=1;
                    else
                        cout<<"    Wrong coordinates:";
                }
            else
                cout<<"    Wrong coordinates:";
        }
        okkk=0;
        select(lin[coox],col[cooy]);
        xx=coox;
        yy=cooy;
        dis=1;
        ok10=0;
        while(okkk==0)
        {
            afisare();
            if (sahh==1)
                cout<<"    You are in check:";
            sahh=0;
            if (dis==1)
            {
                xx=coox;
                yy=cooy;
                cout<<"    Move on coordinates:";
            }
            if (ok10==1 && dis==0)
                cout<<"    Move rejected. Retry:";
            dis=0;
            ok10=0;
            if (verificarecoo()==1)
            {
                aranjare();
                if (coox==xx && cooy==yy)
                {
                    dis=1;
                    deselect(lin[coox],col[cooy]);
                    okk=0;
                    afisare();
                    cout<<"    New coordinates:";
                    while(okk==0)
                    {
                        if (verificarecoo()==1)
                            if (sw==1)
                            {
                                aranjare();
                                if(t[coox][cooy]>0)
                                    okk=1;
                                else
                                    cout<<"    Wrong coordinates:";
                            }
                            else
                            {
                                aranjare();
                                if(t[coox][cooy]<0)
                                    okk=1;
                                else
                                    cout<<"    Wrong coordinates:";
                            }
                        else
                            cout<<"    Wrong coordinates:";
                    }
                    select(lin[coox],col[cooy]);
                }
            }
            if(mutare(xx,yy,coox,cooy)==1)
            {
                if (sw==1)
                {
                    if (xx==8 && yy==1)
                        albe[1]=0;
                    if (xx==8 && yy==5)
                    {
                        albe[2]=0;
                    }
                    if (xx==8 && yy==8)
                        albe[3]=0;
                }
                else
                {
                    if (xx==8 && yy==1)
                        negre[1]=0;
                    if (xx==8 && yy==4)
                        negre[2]=0;
                    if (xx==8 && yy==8)
                        negre[3]=0;
                }
                if (t[xx][yy]==6)
                {
                    xra=coox;
                    yra=cooy;
                }
                if (t[xx][yy]==-6)
                {
                    xrn=coox;
                    yrn=cooy;
                }
                if (sw==1)
                {
                    if (sah(xra,yra)==0)
                    {
                        v2=t[coox][cooy];
                        t[coox][cooy]=t[xx][yy];
                        t[xx][yy]=0;
                        if (sah(xra,yra)==0)
                        {
                            okkk=1;
                            deselect(lin[xx],col[yy]);
                            stergere(lin[xx],col[yy]);
                            scriere(coox,cooy);
                        }
                        else
                        {
                            t[xx][yy]=t[coox][cooy];
                            t[coox][cooy]=v2;
                        }
                    }
                    else
                    {
                        sahh=1;
                        v=t[coox][cooy];
                        t[coox][cooy]=9;
                        if (sah(xra,yra)==0)
                        {
                            sahh=0;
                            okkk=1;
                            t[coox][cooy]=t[xx][yy];
                            t[xx][yy]=0;
                            deselect(lin[xx],col[yy]);
                            stergere(lin[xx],col[yy]);
                            scriere(coox,cooy);
                        }
                        else
                        {
                            t[coox][cooy]=v;
                        }
                    }
                }
                else
                {
                    if (sah(xrn,yrn)==0)
                    {
                        v2=t[coox][cooy];
                        t[coox][cooy]=t[xx][yy];
                        t[xx][yy]=0;
                        if (sah(xrn,yrn)==0)
                        {
                            okkk=1;
                            deselect(lin[xx],col[yy]);
                            stergere(lin[xx],col[yy]);
                            scriere(coox,cooy);
                        }
                        else
                        {
                            t[xx][yy]=t[coox][cooy];
                            t[coox][cooy]=v2;
                        }
                    }
                    else
                    {
                        sahh=1;
                        v=t[coox][cooy];
                        t[coox][cooy]=9;
                        if (sah(xrn,yrn)==0)
                        {
                            sahh=0;
                            okkk=1;
                            t[coox][cooy]=t[xx][yy];
                            t[xx][yy]=0;
                            deselect(lin[xx],col[yy]);
                            stergere(lin[xx],col[yy]);
                            scriere(coox,cooy);
                        }
                        else
                        {
                            t[coox][cooy]=v;
                        }
                    }
                }

            }
            else
            {
                ok10=1;
                if (sw==1)
                {
                    if (xx==8 && yy==5)
                    {
                        if (albe[1]==1 && albe[2]==1 && coox==8 && cooy==1)
                        {
                            if (verifrocada(xx,yy,coox,cooy)==1)
                            {
                                albe[1]=0;
                                albe[2]=0;
                                deselect(lin[xx],col[yy]);
                                rocada(xx,yy,coox,cooy);
                                okkk=1;
                            }
                        }
                        else
                        {
                            if (albe[2]==1 && albe[3]==1 && coox==8 && cooy==8)
                            {
                                if (verifrocada(xx,yy,coox,cooy)==1)
                                {
                                    albe[2]=0;
                                    albe[3]=0;
                                    deselect(lin[xx],col[yy]);
                                    rocada(xx,yy,coox,cooy);
                                    okkk=1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (xx==8 && yy==4)
                    {
                        if (negre[1]==1 && negre[2]==1 && coox==8 && cooy==1)
                        {
                            if (verifrocada(xx,yy,coox,cooy)==1)
                            {
                                negre[1]=0;
                                negre[2]=0;
                                deselect(lin[xx],col[yy]);
                                rocada(xx,yy,coox,cooy);
                                okkk=1;
                            }
                        }
                        else
                        {
                            if (negre[2]==1 && negre[3]==1 && coox==8 && cooy==8)
                            {
                                if (verifrocada(xx,yy,coox,cooy)==1)
                                {
                                    negre[2]=0;
                                    negre[3]=0;
                                    deselect(lin[xx],col[yy]);
                                    rocada(xx,yy,coox,cooy);
                                    okkk=1;

                                }
                            }
                        }
                    }
                }
            }
        }
        i=1;
        for (j=1;j<=8;j++)
        {
            if (sw==1)
            {
                if (t[i][j]==1)
                {
                    schimbarepion(i,j);
                }
            }
            else
            {
                if (t[i][j]==-1)
                {
                    schimbarepion(i,j);
                }
            }
        }
        flip();
        if (sw==1)
        {
            if (sah(xrn,yrn)==1)
            {
                if(sahmat(xrn,yrn)==1)
                {
                    ok=0;
                    sm=1;
                }
            }
        }
        else
        {
            if (sah(xra,yra)==1)
            {
                if (sahmat(xra,yra)==1)
                {
                    ok=0;
                    sm=1;
                }
            }
        }
        if (sw==1)
        {
            if (pat(xrn,yrn)==0)
            {
                ok=0;
            }
        }
        else
        {
            if (pat(xra,yra)==0)
            {
                ok=0;
            }
        }
    }
    afisare();
    if (sm==1)
    {
        cout<<"    Check Mate !!!"<<endl<<endl;
        cout<<"    The winner is ";
        if (sw==1)
            cout<<p1<<" !!!";
        else
            cout<<p2<<" !!!";
    }
    else
        cout<<"    Pat !!! Draw.";

//--------------------------------------------------------------------------------------------
}
